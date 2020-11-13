using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class PrescriptionDTO
    {
        public bool Reserved { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public List<Guid> TheraphyId = new List<Guid>();

    }
}
