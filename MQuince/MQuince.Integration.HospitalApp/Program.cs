using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQuince.Integration.Entities;

namespace MQuince.Integration.HospitalApp
{
    public class Program
    {
        public static List<ActionsAndBenefits> ActionAndBenefitMessage = new List<ActionsAndBenefits>();


        public static void Main(string[] args)
        {
            /*ActionsAndBenefits a = new ActionsAndBenefits("Apoteka1", "Akcija1", new DateTime(2020, 12, 10), new DateTime(2020, 12, 21), 1000, 600);
            Console.WriteLine("AKCIJA:" + a.PharmacyName + " -> " + a.IsApproved.ToString());
            a.IsApproved = true;
            Console.WriteLine("AKCIJA ODOBRENA:" + a.PharmacyName + "-> "+ a.IsApproved.ToString());*/
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>

                {
                    services.AddHostedService<ClientScheduledService>();
                    services.AddHostedService<RabbitMQService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>

                {
                    webBuilder.UseStartup<Startup>();
                });
        public static IHostBuilder ActionAndBenefitMessages(string[] args) =>
          Host.CreateDefaultBuilder(args)
          .UseWindowsService()
          .ConfigureServices((hostContext, services) =>
          {
              services.AddHostedService<RabbitMQService>();
              services.AddHostedService<ClientScheduledService>();
          });
    }
}
