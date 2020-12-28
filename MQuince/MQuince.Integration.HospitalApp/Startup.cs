using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MQuince.Integration.Repository.MySQL.DataProvider;
using MQuince.Integration.Services.Constracts.Interfaces;
using MQuince.Integration.Services.Implementation;

using Microsoft.EntityFrameworkCore;
using Grpc.Core;
using MQuince.Integration.HospitalApp.Protos;


namespace MQuince.Integration.HospitalApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } 
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=pharmacydb");
            services.AddTransient(typeof(IPharmacyService), s => new PharmacyService(new PharmacyRepository(dbContextOptionsBuilder)));
            services.AddTransient(typeof(IMedicationsConsumptionService), s => new MedicationsConsumptationService(new MedicationsConsumptionRepository(dbContextOptionsBuilder)));
            services.AddTransient(typeof(ISftpService), s => new SftpService());
            services.AddTransient(typeof(ITenderService), s => new TenderService(new TenderRepository(dbContextOptionsBuilder)));

            services.AddMvc().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.Culture = new CultureInfo("tr-TR");
            });
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;

            }).AddNewtonsoftJson();
        }
        private Server server;

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Views")),
                RequestPath = "/Views"
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>

            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            server = new Server
            {
                Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
                Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
            };
            server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutdown);


        }
        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }

        }
    }
}
