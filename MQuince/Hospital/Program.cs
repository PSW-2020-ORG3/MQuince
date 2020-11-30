using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQuince.IntegrationMySQL.Model;

namespace Hospital
{
    public class Program
    {
        public static List<ActionsAndBenefits> ActionAndBenefitMessage = new List<ActionsAndBenefits>();
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build();
            ActionAndBenefitMessages(args).Build().Run();

        }
        public static IHostBuilder ActionAndBenefitMessages(string[] args) =>
          Host.CreateDefaultBuilder(args)
          .UseWindowsService()
          .ConfigureServices((hostContext, services) =>
          {
              Console.WriteLine("ajdee");
              services.AddHostedService<RabbitMQService>();
          });
        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });
    }
}
