using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp.Controllers
{
    
     [Route("api/GrpcController")]
     [ApiController]
     public class GrpcController : ControllerBase
     {
       
            ClientScheduledService service;
            public GrpcController()
            {
                service = new ClientScheduledService();
            }

            
            [HttpPost]
            public IActionResult PostMedicineDescriptionGrpc([FromBody] object name)
            {
                string json = name.ToString();
                dynamic result = JObject.Parse(json);
                var nameMedicine = result.name;
                var quantityOfMedicine = result.quantity;
                service.SendMessage(nameMedicine.ToString(), quantityOfMedicine.toString());
                return Ok("Drug: "+nameMedicine);
            }

     }
}
