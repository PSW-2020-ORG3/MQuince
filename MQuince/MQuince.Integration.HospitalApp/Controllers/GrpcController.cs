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
            public IActionResult PostMedicineDescriptionGrpc([FromBody] object obj)
            {
            string json = obj.ToString();
            dynamic result = JObject.Parse(json);
            var nameMedicine = result.name;
            var quantityOfMedicine = result.quantity;
            Console.WriteLine("Name medication :" + nameMedicine + " quantity :" + quantityOfMedicine);
            service.SendMessage(nameMedicine.ToString(), (string)quantityOfMedicine);
            return Ok("Drug: " + nameMedicine);

        }

    }
}
