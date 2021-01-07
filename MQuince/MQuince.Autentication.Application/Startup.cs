using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQuince.Autentication.Application.Services;
using MQuince.Autentication.Contracts.Service;
using MQuince.Autentication.Infrastructure;
using System;

namespace MQuince.Autentication.Application
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
            services.AddControllers();

            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";
            stage = ExtractArgument(stage);

            if (stage == "dev")
            {
                dbContextOptionsBuilder.UseMySql(CreateConnectionStringFromEnvironment());
            } else
            {
                dbContextOptionsBuilder.UseNpgsql(CreateConnectionStringFromEnvironment());
            }
            services.AddTransient(typeof(IUserService), s => new UserService(new UserRepository(dbContextOptionsBuilder)));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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
