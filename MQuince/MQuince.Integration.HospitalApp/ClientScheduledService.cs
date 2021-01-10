using Grpc.Core;
using Microsoft.Extensions.Hosting;
using MQuince.Integration.Entities;
using MQuince.Integration.HospitalApp.Protos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace MQuince.Integration.HospitalApp
{
    public class ClientScheduledService : IHostedService
    {
        private System.Timers.Timer timer;
        public static List<GrpcMessage> MessageGrpc = new List<GrpcMessage>();
        public static List<GrpcMessage> MessageForUrgentProcurement = new List<GrpcMessage>();

        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;
        public ClientScheduledService()
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new Protos.SpringGrpcService.SpringGrpcServiceClient(channel);
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new System.Timers.Timer();
            timer.Enabled = false;
            return Task.CompletedTask;
        }

        
        public async void SendUrgentMessage(string name, string quantity)

        {
            try
            {  
                MessagePharmacyResponse response = await client.communicateAsync(new MessagePharmacy() { Name = name, Quantity = quantity });
                GrpcMessage message = new GrpcMessage(response.Name, response.Status);
                MessageForUrgentProcurement.Add(message);

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }

        public async void SendMessageGrpc(string name, string quantity)
        {
            try
            {
                MessagePharmacyResponse response = await client.communicateAsync(new MessagePharmacy() { Name = name, Quantity = quantity });
                GrpcMessage message = new GrpcMessage(response.Name, response.Status);
                MessageGrpc.Add(message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel?.ShutdownAsync();
            return Task.CompletedTask;
        }
    }
}