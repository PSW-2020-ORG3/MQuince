using Grpc.Core;
using Microsoft.Extensions.Hosting;
using MQuince.Integration.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace MQuince.Integration.HospitalApp
{
    public class ClientScheduledService : IHostedService
    {
        private System.Timers.Timer timer;
        public static List<GrpcMessage> MessageGrpc = new List<GrpcMessage>();
        private Channel channel;
        private Protos.SpringGrpcService.SpringGrpcServiceClient client;
        private object source;
        private ElapsedEventArgs e;
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

        public async void SendMessage(string name)

        {

            try
            {
                Protos.MessagePharmacyResponse response = await client.communicateAsync(new Protos.MessagePharmacy() { Name = name });
                Console.WriteLine("Medication:" + response.Name + " is " + response.Status + "in pharmacy!");
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