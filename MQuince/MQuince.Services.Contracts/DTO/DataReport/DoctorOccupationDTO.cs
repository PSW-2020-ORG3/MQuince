using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataReport
{
    public class DoctorOccupationDTO
    {
        public int TotalWorkTime { get; set; }
        public int OccupationWorkTime { get; set; }
        public Doctor DoctorId { get; set; }
    }
}
