using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQuince.IntegrationMySQL.Interfaces;
using MQuince.IntegrationMySQL.Repository;
using MQuince.IntegrationMySQL.Services;
using MQuince.IntegrationMySQL.STFP;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using MQuince.IntegrationMySQL.Pharmacy;
using System.Globalization;
using Newtonsoft.Json;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Hospital
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
      


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=pharmacydb");
            services.AddTransient(typeof(IPharmacyServices), s => new PharmacyServices(new PharmacyRepository(dbContextOptionsBuilder)));
            services.AddTransient(typeof(IMedicationsConsumptionService), s => new MedicationsConsumptationService(new MedicationsConsumptionRepository(dbContextOptionsBuilder)));
            services.AddTransient(typeof(ISftpService), s => new SftpService());
            //services.AddMvc().AddNewtonsoftJson();
            //services.AddControllers().AddNewtonsoftJson();
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Culture = new CultureInfo("tr-TR");
            });






            services.AddControllers(options =>
        {
            options.EnableEndpointRouting = false;

        });
         /* .AddNewtonsoftJson(options => { 
              options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
              options.SerializerSettings.Culture = new CultureInfo("tr-TR");
          });
         */
         

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

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Views")),
                RequestPath = "/Views"
            });
            

            app.UseRouting();

            app.UseAuthorization();

            /*
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
