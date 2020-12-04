﻿using Microsoft.Extensions.Hosting;
using MQuince.Integration.Entities;
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
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "Mquince",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                ActionsAndBenefits message = null;
                try
                {   
                    message = JsonConvert.DeserializeObject<ActionsAndBenefits>(jsonMessage);
                }
                catch (Exception)    
                {
                    //message = JsonConvert.DeserializeObject<ActionAndBenefit>(jsonMessage, new MyDateTimeConverter());
                }
                Console.WriteLine(" [x] Received {0}", message);
                Program.ActionAndBenefitMessage.Add(message);



            };
            channel.BasicConsume(queue: "Mquince",
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