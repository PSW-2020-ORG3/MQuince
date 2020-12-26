using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Syncfusion.Pdf.Barcode;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using Syncfusion.Pdf.Graphics;
using PdfSharp.Drawing;
using MQuince.Integration.Services.Constracts.Interfaces;
using MQuince.Integration.Services.Implementation;
using MQuince.Integration.Entities;
using System.Collections.Generic;

namespace MQuince.Integration.HospitalApp.Controllers
{
    public class HomeController : Controller
    {

        List<GrpcMessage> messageGrpc = ClientScheduledService.MessageGrpc;
        List<ActionsAndBenefits> action = Program.ActionAndBenefitMessage;

        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is Welcome action method";
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult getSpecification()
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
        public IActionResult sendMessageGrpc()
        {
            return View(messageGrpc);
        }
        public IActionResult ActionAndBenefits()
        {
            return View(action);
        }
    }
}