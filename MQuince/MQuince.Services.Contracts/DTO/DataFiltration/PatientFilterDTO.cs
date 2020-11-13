using MQuince.Entities.Diagnosis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataFiltration
{
    public class PatientFilterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RecordNumber { get; set; }
        public string Jmbg { get; set; }
        public Entities.Diagnosis.Diagnosis diagnosis { get; set; }

    }
}
