using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQuince.Infrastructure.DataAccess;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Reflection;

namespace MQuince.APIGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            if (String.Equals(Environment.GetEnvironmentVariable("SHOW_ENV"), "TRUE"))
                ShowConfig(configuration);
        }

        private void ShowConfig(IConfiguration config)
        {
            foreach (var pair in config.GetChildren())
            {
                Console.WriteLine($"{pair.Path} - {pair.Value}");
                ShowConfig(pair);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";
            stage = ExtractArgument(stage);

            if (stage == "dev")
            {
                services.AddDbContext<MQuinceDbContext>(options =>
                options.UseMySql(CreateConnectionStringFromEnvironment(),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
            }
            else
            {
                services.AddDbContext<MQuinceDbContext>(options =>
                options.UseNpgsql(CreateConnectionStringFromEnvironment(),
                b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
            }

            services.AddOcelot();

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp";
            });
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MQuinceDbContext>();
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                if (stage == "test")
                {
                    if (!databaseCreator.HasTables())
                    {
                        context.Database.Migrate();
                    }
                }
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseOcelot().Wait();
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_DOMAIN") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "mquince";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";

            stage = ExtractArgument(stage);
            server = ExtractArgument(server);
            port = ExtractArgument(port);
            database = ExtractArgument(database);
            user = ExtractArgument(user);
            password = ExtractArgument(password);

            if (stage == "dev")
            {
                Console.WriteLine($"server={server};port={port};database={database};user={user};password={password};");
                return $"server={server};port={port};database={database};user={user};password={password};";
            }
            else
            {
                return $"Server={server};Port={port};Database={database};Username={user};Password={password};";
            }
        }

        private string ExtractArgument(string argument)
        {
            string retVal = argument.Replace("=", "");
            return retVal.Trim();
        }
    }
}
