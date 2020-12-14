﻿using System;
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

namespace MQuince.Integration.HospitalApp.Controllers
{
    public class HomeController : Controller
    {
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
            generateQRCode(name, jmbg, medication, description);            
            return View();
        }

        private void generateQRCode(string name, string jmbg, string medication, string description)
        {
            string input = name + " \n " + jmbg + " \n " + DateTime.Today + " \n " + medication + " \n " + description;
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator QR = new QRCodeGenerator();
                QRCodeData qrData = QR.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);
                using (Bitmap oBitmap = qrCode.GetGraphic(5))
                {
                    oBitmap.Save(ms, ImageFormat.Png);
                    ViewBag.QRCode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    GeneratePDF(name, jmbg, medication, description, ms, qrCode);
                }

            }

        }

        private void GeneratePDF(string name, string jmbg, string medication, string description, MemoryStream ms, QRCode qrCode)
        {
            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(jmbg+"_"+ DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".pdf", FileMode.Create));
            document.Open();
                

           Paragraph paragraph = new Paragraph();
            string header = "Prescription for medication:";
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20f, BaseColor.BLACK);
            paragraph.Add(header);
            paragraph.SpacingBefore = 10;
            paragraph.SpacingAfter = 10;
            document.Add(paragraph);

            string nameHeader = "Pacient name:      ";
            string jmbgHeader = "JMBG:      ";
            string medicationHeader = "Medication:      ";
            string descriptionHeader = "Description:       ";
            string dateHeader = "Date of perscription:      ";
            string date = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".  @  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

            
            Paragraph about = new Paragraph();
            about.Add(nameHeader);
            about.SpacingBefore = 3;
            about.SpacingAfter = 5;
            about.Alignment = Element.ALIGN_LEFT;  

            about.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            about.Add(name);
            document.Add(about);


            Paragraph j = new Paragraph();
            j.Add(jmbgHeader);
            j.SpacingBefore = 3;
            j.SpacingAfter = 5;
            j.Alignment = Element.ALIGN_LEFT;

            j.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            j.Add(jmbg);
            document.Add(j);

            Paragraph d = new Paragraph();
            d.Add(dateHeader);
            d.SpacingBefore = 3;
            d.SpacingAfter = 5;
            d.Alignment = Element.ALIGN_LEFT;

            d.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            d.Add(date);
            document.Add(d);


            Paragraph m = new Paragraph();
            m.Add(medicationHeader);
            m.SpacingBefore = 3;
            m.SpacingAfter = 5;
            m.Alignment = Element.ALIGN_LEFT;

            m.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            m.Add(medication);
            document.Add(m);

            Paragraph o = new Paragraph();
            o.Add(descriptionHeader);
            o.SpacingBefore = 3;
            o.SpacingAfter = 5;
            o.Alignment = Element.ALIGN_LEFT;

            o.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            o.Add(description);
            document.Add(o);
            
            Paragraph qr = new Paragraph();

            iTextSharp.text.pdf.BarcodeQRCode qrcode = new BarcodeQRCode(name + " \n " + jmbg + " \n " + DateTime.Today + " \n " + medication + " \n " + description, 200, 200, null);
            iTextSharp.text.Image image = qrcode.GetImage();
            document.Add(image);


            Paragraph po = new Paragraph();
            po.Add("MSVK  -  dr Marijana Majkic");
            o.SpacingBefore = 3;
            o.SpacingAfter = 5;
            document.Add(po);
            document.Close();               
        }


    }
}
