using Microsoft.AspNetCore.Mvc;
﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Syncfusion.Pdf.Barcode;
using System.Drawing.Drawing2D;
using Syncfusion.Pdf.Graphics;
using PdfSharp.Drawing;
using System.Collections.Generic;
using MQuince.Sftp.Services;
using MQuince.UrgentProcurement.Services;
using MQuince.UrgentProcurement.Domain;

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


       
        [HttpPost]
        public IActionResult PrescribeTherapy(string name, string jmbg, string medication, string description)
        {
            HomeService.generateQRCode(name, jmbg, medication, description);
            return View();
        }

        public IActionResult urgentMessage()
        {
            return View(messageForUrgentProcurement);
        }
        
        public IActionResult tender()
        {
            return View();
        }
        
        public IActionResult ViewTender()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult ShowAllOffers()
        {
            return View();
        }

        public IActionResult requestForDirector()
        {
            return View(messageForUrgentProcurement);
        }
    }
}