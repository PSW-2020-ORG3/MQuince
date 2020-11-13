using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class StaffDTO
    {
        public EducationLevel EducationLevel { get; set; }
        public string Picture { get; set; }
        public int PictureNumber { get; set; }
    }
}
