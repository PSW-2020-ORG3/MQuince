using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class WorkTimeDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Guid> WorkDayId { get; set; }
        public Guid StaffId { get; set; }
    }
}
