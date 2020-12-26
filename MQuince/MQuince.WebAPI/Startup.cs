using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQuince.Application;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Services.Contracts.Interfaces;
using VueCliMiddleware;

namespace MQuince.WebAPI
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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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

            App application = new App(CreateConnectionStringFromEnvironment());

            services.AddTransient(typeof(IUserService), s => application.GetUserService());
            services.AddTransient(typeof(IFeedbackService), s => application.GetFeedbackService());
            services.AddTransient(typeof(ISpecializationService), s => application.GetSpecializationService());
            services.AddTransient(typeof(IDoctorService), s => application.GetDoctorService());
            services.AddTransient(typeof(IAppointmentService), s => application.GetAppointmentService());

            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp";
            });

            services.AddDbContext<MQuinceDbContext>();
        }

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

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSpaStaticFiles();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "ClientApp";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });
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
