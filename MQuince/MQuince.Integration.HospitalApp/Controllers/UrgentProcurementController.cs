using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/UrgentProcurementController")]
    [ApiController]
    public class UrgentProcurementController : ControllerBase
    {

        ClientScheduledService service;
        public UrgentProcurementController()
        {
            service = new ClientScheduledService();
        }
        [HttpPost]
        public IActionResult PostUrgentProcurement([FromBody] object obj)
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
