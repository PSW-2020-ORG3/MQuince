using Grpc.Core;
using MQuince.Integration.HospitalApp.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        /*  public override Task<MessagePharmacyResponse> getDrug(MessagePharmacy request, ServerCallContext context)
          {
              Console.WriteLine(request.Name + " from spring; random int: " + request.RandomInteger.ToString());
              MessagePharmacyResponse response = new MessagePharmacyResponse();
              response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
              response.Status = "STATUS OK";
              return Task.FromResult(response);
          }
          */
    }
}
