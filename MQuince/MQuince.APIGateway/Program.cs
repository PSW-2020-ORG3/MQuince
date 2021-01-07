using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MQuince.APIGateway
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            string stage = Environment.GetEnvironmentVariable("STAGE") ?? "dev";
            stage = ExtractArgument(stage);
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(config =>
                     config.AddJsonFile($"ocelot.{stage}.json"));
                });
        }
            
        private static string ExtractArgument(string argument)
        {
            string retVal = argument.Replace("=", "");
            return retVal.Trim();
        }
    }
}
