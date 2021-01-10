using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using MQuince.Integration.Services.Implementation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp.Controllers
{


    [Route("api/[controller]")]
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
            service.SendMessageGrpc(nameMedicine.ToString(), (string)quantityOfMedicine);
            return Ok("Drug: " + nameMedicine);

        }
    }
}