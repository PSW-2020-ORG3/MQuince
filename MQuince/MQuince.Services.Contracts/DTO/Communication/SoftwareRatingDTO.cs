using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class SoftwareRatingDTO
    {
        public Grade Functionality { get; set; }
        public Grade Speed { get; set; }
        public Grade Reliabillity { get; set; }
        public Grade Design { get; set; }
        public string Note { get; set; }
    }
}
