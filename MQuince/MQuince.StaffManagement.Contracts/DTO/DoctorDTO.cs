using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.DTO
{
    public class DoctorDTO : StaffDTO
    {
        public string Biography { get; set; }
        public Guid Specialization { get; set; }
    }
}
