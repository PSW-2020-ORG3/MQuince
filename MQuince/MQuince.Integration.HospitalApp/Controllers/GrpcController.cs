using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController: ControllerBase
    {
        public GrpcController()
        {
        }

        [HttpGet("grpc/recieve/{medicine}")]
        public IActionResult GetMedicineDescriptionGrpc(string medicine)
        {
            string response = new ClientScheduledService().SendMessage(medicine).Result;
            return Ok();
        }
    }
}
