using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Diagnosis
{
    public class DiagnosisDTO
    {
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Theraphy { get; set; }
        public List<Guid> SymptomsId = new List<Guid>();
        public List<Guid> TheraphyDrugsId = new List<Guid>();
        public string DoctorCreated { get; set; }
    }
}
