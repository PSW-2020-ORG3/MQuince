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
using MQuince.IntegrationMySQL.Services;
using MQuince.IntegrationMySQL.DTO;

namespace Hospital.Controllers
{
    [Route("api/sftpKontroler")]
    [ApiController]
    public class SftpController : ControllerBase
    {

        private readonly SftpService _sftpService;

        private readonly IMedicationsConsumptionService _medicationsConsumptationService;
        IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> medicationstList = null;
        
        public SftpController(IMedicationsConsumptionService medicationsConsumptionService)
        {
            this._sftpService = new SftpService();
            this._medicationsConsumptationService = medicationsConsumptionService;

        }

        [HttpPost]
        public IActionResult AddDates(DateDTO dto)
        {
            
            if (dto.From >= dto.To)
            {
                return BadRequest("Bad dates!");
            }
            return Get(dto);
            
        }



        [HttpGet]
        public IActionResult Get(DateDTO dto)
        {
            medicationstList = _medicationsConsumptationService.GetAll().ToList();
            
            if (medicationstList  == null)
            {
                return BadRequest();
            }
            

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("izvjestaj.pdf", FileMode.Create));
            doc.Open();
            
            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("\t\t Medications consumption records \n");
            doc.Add(p);


           foreach (IdentifiableDTO<MedicationsConsumptionDTO> medication in medicationstList)
           {
              if(medication.EntityDTO.DateOfConsumtion >= dto.From && medication.EntityDTO.DateOfConsumtion <= dto.To)
                {
                 iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph("\n Name:  " + medication.EntityDTO.Name + "  -- Quantity: " + medication.EntityDTO.Quantity + " -- Date: " + medication.EntityDTO.DateOfConsumtion);
                 doc.Add(p1);
                }
            }
            doc.Close(); 
            
            if (_sftpService.SendFile("izvjestaj.pdf"))
                    return Ok();
            else
                return BadRequest();
            
                  
        }
    }
}
