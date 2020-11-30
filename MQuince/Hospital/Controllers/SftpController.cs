using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.IntegrationMySQL.STFP;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;

namespace Hospital.Controllers
{
    [Route("api/sftpKontroler")]
    [ApiController]
    public class SftpController : ControllerBase
    {

        private readonly SftpService _sftpService;

        public SftpController()
        {
            this._sftpService =new SftpService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            DateTime datum = new DateTime(2020, 03, 20);
            String lijek = "Brufen";
            int kolicina = 3;

            String d = datum.ToString();
            String[] dat = d.Split(' ');
            String izvjestaj = "izjestaj-" +dat[0]+".pdf";
           

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("izvjestaj.pdf", FileMode.Create));
            doc.Open();
            
                iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("                                                     IZVJESTAJ O KORISCENJU TERAPIJE\n");
                iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph("\nLijek " + lijek + " ,kolicina " + kolicina + " ,datum " + datum);
                iTextSharp.text.Paragraph p2 = new iTextSharp.text.Paragraph("\nPonedjeljak: 08:00h jedna tableta\n                    14:00h dvije tablete\n                    19:00h jedna tableta" +
                    "\nUtorak: 08:00h jedna tableta\n             14:00h dvije tablete\n             19:00h jedna tableta" +
                    "\nSrijeda: 08:00h jedna tableta\n             14:00h dvije tablete\n             19:00h jedna tableta" +
                    " \nNedelja:08:00h jedna tableta\n             14:00h dvije tablete\n             19:00h jedna tableta" +
                    " \n");
                doc.Add(p);
                doc.Add(p1);
                doc.Add(p2);
            

            doc.Close();
            
        
            

            //if (_sftpService.SendFile("test.txt"))
            if (_sftpService.SendFile("izvjestaj.pdf"))
                    return Ok();
            else
                return BadRequest();

        }
    }
}
