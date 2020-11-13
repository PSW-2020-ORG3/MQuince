using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class PatientDTO
    {
        public bool Guest { get; set; }
        public BloodType BloodType { get; set; }
        public Rhfactor RhFactor { get; set; }
        public Guid MedicalRecordId { get; set; }
    }
}
