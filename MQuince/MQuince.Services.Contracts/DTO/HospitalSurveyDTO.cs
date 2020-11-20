using MQuince.Entities.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO
{
    public class HospitalSurveyDTO
    {
        public Question Question { get; set; }
        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        public int FiveStar { get; set; }
    }
}
