
using Microsoft.Extensions.Hosting;
using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.ActionAndBenefits.Contracts.Service;
using MQuince.ActionAndBenefits.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MQuince.ActionAndBenefits.Services
{
    public class RabbitMQService : BackgroundService
    {
        IConnection connection;
        IModel channel;
        
        private readonly IActionAndBenefitsService _actionAndBenefitsService;

        public RabbitMQService(IActionAndBenefitsService actionAndBenefitsService)
        {
            this._actionAndBenefitsService = actionAndBenefitsService;
        }

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
                    ActionAndBenefitsDTO newAction = new ActionAndBenefitsDTO(                        
                        message.PharmacyName,
                        message.ActionName,
                        new DateTime(message.BeginDate.Year, message.BeginDate.Month, message.BeginDate.Day),
                        new DateTime(message.EndDate.Year, message.EndDate.Month, message.EndDate.Day),
                        Convert.ToDouble(message.OldCost),
                        Convert.ToDouble(message.NewCost),
                        false
                        );
                   
                   _actionAndBenefitsService.Create(newAction);

                }
                catch (Exception e)
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
