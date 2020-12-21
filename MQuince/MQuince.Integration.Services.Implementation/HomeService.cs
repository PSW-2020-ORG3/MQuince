
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using MQuince.Integration.Services.Constracts.Interfaces;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MQuince.Integration.Services.Implementation
{
    public class HomeService 
    {       
        public static void GeneratePDF(string name, string jmbg, string medication, string description, MemoryStream ms, QRCoder.QRCode qrCode)
        {
            Document document = new Document(PageSize.A4, 10, 10, 10, 10);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(jmbg + "_" + DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + ".pdf", FileMode.Create));
            document.Open();
            AddPerscriptionToPdf(document, name, jmbg,medication,description);      
            document.Close();
        
        }

        private static void AddPerscriptionToPdf(Document document, string name, string jmbg, string medication, string description)
        {
            document.Add(GenerateParagraphForTitle());
            document.Add(GenerateParagraphForPatientName(name));
            document.Add(GenerateParagraphForJmbg(jmbg));
            document.Add(GenerateParagraphForDatePerscription());
            document.Add(GenerateParagraphForMedication(medication));
            document.Add(GenerateParagraphForDecsription(description));
            document.Add(GenerateParagraphForQRCode(name, jmbg, medication, description));
            document.Add(GenerateParagraphForPhamracyName());
        }

        private static Paragraph GenerateParagraphForPhamracyName()
        {
            Paragraph phamracyNameParagraph = new Paragraph();
            phamracyNameParagraph.Add("MSVK  -  dr Marijana Majkic");
            phamracyNameParagraph.SpacingBefore = 3;
            phamracyNameParagraph.SpacingAfter = 5;
            return phamracyNameParagraph;
        }

        private static Paragraph GenerateParagraphForQRCode(string name, string jmbg, string medication, string description)
        {
            Paragraph qrPahragraph = new Paragraph();
            iTextSharp.text.pdf.BarcodeQRCode qrcode = new BarcodeQRCode(name + " \n " + jmbg + " \n " + DateTime.Today + " \n " + medication + " \n " + description, 200, 200, null);
            iTextSharp.text.Image image = qrcode.GetImage();
            qrPahragraph.Add(image);
            return qrPahragraph;

        }

        private static Paragraph GenerateParagraphForDecsription(string description)
        {
            string descriptionHeader = "Description:       ";
            Paragraph descriptionParagraph = new Paragraph();
            descriptionParagraph.Add(descriptionHeader);
            descriptionParagraph.SpacingBefore = 3;
            descriptionParagraph.SpacingAfter = 5;
            descriptionParagraph.Alignment = Element.ALIGN_LEFT;
            descriptionParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            descriptionParagraph.Add(description);
            return descriptionParagraph;
        }

        private static Paragraph GenerateParagraphForMedication(string medication)
        {
            string medicationHeader = "Medication:      ";
            Paragraph medicationParagrapht = new Paragraph();
            medicationParagrapht.Add(medicationHeader);
            medicationParagrapht.SpacingBefore = 3;
            medicationParagrapht.SpacingAfter = 5;
            medicationParagrapht.Alignment = Element.ALIGN_LEFT;

            medicationParagrapht.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            medicationParagrapht.Add(medication);
            return medicationParagrapht;
        }

        private static Paragraph GenerateParagraphForDatePerscription()
        {
            string date = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".  @  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            string dateHeader = "Date of perscription:      ";
            Paragraph dateParagraph = new Paragraph();
            dateParagraph.Add(dateHeader);
            dateParagraph.SpacingBefore = 3;
            dateParagraph.SpacingAfter = 5;
            dateParagraph.Alignment = Element.ALIGN_LEFT;

            dateParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            dateParagraph.Add(date);
            return dateParagraph;
        }

        private static Paragraph GenerateParagraphForJmbg(string jmbg)
        {

            string jmbgHeader = "JMBG:      ";
            Paragraph jmbgParagraph = new Paragraph();
            jmbgParagraph.Add(jmbgHeader);
            jmbgParagraph.SpacingBefore = 3;
            jmbgParagraph.SpacingAfter = 5;
            jmbgParagraph.Alignment = Element.ALIGN_LEFT;
            jmbgParagraph.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            jmbgParagraph.Add(jmbg);
            return jmbgParagraph;
            
        }

        private static Paragraph GenerateParagraphForPatientName(string name)
        {
            string nameHeader = "Pacient name:      ";
            Paragraph about = new Paragraph();
            about.Add(nameHeader);
            about.SpacingBefore = 3;
            about.SpacingAfter = 5;
            about.Alignment = Element.ALIGN_LEFT;
            about.Font = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 12f, BaseColor.BLACK);
            about.Add(name);
            return about;
        }

        private static Paragraph GenerateParagraphForTitle()
        {
            Paragraph paragraph = new Paragraph();
            string header = "Prescription for medication:";
            paragraph.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 20f, BaseColor.BLACK);
            paragraph.Add(header);
            paragraph.SpacingBefore = 10;
            paragraph.SpacingAfter = 10;
            return paragraph;

        }



        public static void generateQRCode(string name, string jmbg, string medication, string description)
        {
            string input = name + " \n " + jmbg + " \n " + DateTime.Today + " \n " + medication + " \n " + description;
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator QR = new QRCodeGenerator();
                QRCodeData qrData = QR.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qrCode = new QRCoder.QRCode(qrData);
                using (Bitmap oBitmap = qrCode.GetGraphic(5))
                {
                    oBitmap.Save(ms, ImageFormat.Png);
                    GeneratePDF(name, jmbg, medication, description, ms, qrCode);
                }

            }
        }
    }
}
