using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MQuince.Integration.Entities;
using MQuince.Integration.HospitalApp.Controllers;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Repository.MySQL.DataAccess;
using MQuince.Integration.Repository.MySQL.DataProvider.Util;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        private readonly DbContextOptions _dbContext;
               
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "nina.queue",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string jsonMessage = Encoding.UTF8.GetString(body);
                ActionsAndBenefits message = JsonConvert.DeserializeObject<ActionsAndBenefits>(jsonMessage);
                try
                {
                    using (DataContext _context = new DataContext())
                    {
                        _context.ActionAndBenefits.Add(ActionAndBenefitsMapper.MapActionsAndBenefitsEntityToActionsAndBenefitsPersistance(new ActionsAndBenefits(
                                                message.PharmacyName,
                                                message.ActionName,
                                                new DateTime(message.BeginDate.Year, message.BeginDate.Month, message.BeginDate.Day),
                                                new DateTime(message.EndDate.Year, message.EndDate.Month, message.EndDate.Day),
                                                Convert.ToDouble(message.OldCost),
                                                Convert.ToDouble(message.NewCost))));
                        _context.SaveChanges();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                 };
            channel.BasicConsume(queue: "nina.queue",
                                    autoAck: true,
                                    consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }

}