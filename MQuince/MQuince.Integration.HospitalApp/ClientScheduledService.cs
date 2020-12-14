using Grpc.Core;
using Microsoft.Extensions.Hosting;
using MQuince.Integration.HospitalApp.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace MQuince.Integration.HospitalApp
{
    public class ClientScheduledService :IClientScheduledService
    {
        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }

        public async Task<String> SendMessage ( string name){
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
            MessagePharmacyResponse response = await client.communicateAsync(new MessagePharmacy() { Name = name });
            return response.Name;
       }
    }
}
