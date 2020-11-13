using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class AbsenceDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AbsenceType AbsenceType { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }
        public Guid StaffId { get; set; }
    }
}
