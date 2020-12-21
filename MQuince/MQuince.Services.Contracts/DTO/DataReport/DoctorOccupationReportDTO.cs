using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataReport
{
    public class DoctorOccupationReportDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public WorkPlace WorkPlace { get; set; }
        public List<DoctorOccupationDTO> DoctorOccupation { get; set; }
    }
}
