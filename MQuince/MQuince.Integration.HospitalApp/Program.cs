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
            CreateHostBuilder(args).Build().Run();
            //ActionAndBenefitMessages(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<ClientScheduledService>();
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
          });
    }
}
