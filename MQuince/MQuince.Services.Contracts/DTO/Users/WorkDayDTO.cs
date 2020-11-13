using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class WorkDayDTO
    {
        public Days Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
