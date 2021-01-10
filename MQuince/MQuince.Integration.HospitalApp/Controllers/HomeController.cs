using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Entities;
using MQuince.Integration.Services.Implementation;
using System.Collections.Generic;

namespace MQuince.Integration.HospitalApp.Controllers
{
	public class HomeController : Controller
	{

		List<GrpcMessage> messageGrpc = ClientScheduledService.MessageGrpc;
        List<GrpcMessage> messageForUrgentProcurement = ClientScheduledService.MessageForUrgentProcurement;


		public IActionResult Index()
		{
			return View();
		}

		public string Welcome()
		{
			return "This is Welcome action method";
		}

		public IActionResult AddPharmacy()
		{
			return View();
		}
		public IActionResult SendReports()
		{
			return View();
		}

		public IActionResult GetSpecification()
		{
			return View();
		}

		public IActionResult PrescribeTherapy()
		{
			return View();
		}

		public IActionResult SendMessageGrpc()
		{
			return View(messageGrpc);
		}

		public IActionResult ActionAndBenefits()
		{
			return View();
		}


        public IActionResult Therapy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Therapy(string name, string jmbg, string medication, string description)
        {
            HomeService.generateQRCode(name, jmbg, medication, description);
            return View();
        }

        public IActionResult urgentMessage()
        {
            return View(messageForUrgentProcurement);
        }
        public IActionResult requestForDirector()
        {
            return View(messageForUrgentProcurement);
        }
    }
}