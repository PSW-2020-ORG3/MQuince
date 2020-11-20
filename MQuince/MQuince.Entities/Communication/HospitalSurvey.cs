using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class HospitalSurvey
    {
        private Guid _id;
        public Question Question { get; set; }
        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        public int FiveStar { get; set; }

        public HospitalSurvey() { }
        public HospitalSurvey(Guid id, Question question, int oneStar, int twoStar, int threeStar, int fourStar, int fiveStar)
        {
            _id = id;
            Question = question;
            OneStar = oneStar;
            TwoStar = twoStar;
            ThreeStar = threeStar;
            FourStar = fourStar;
            FiveStar = fiveStar;
        }
        public HospitalSurvey(Question question, int oneStar, int twoStar, int threeStar, int fourStar, int fiveStar) : 
            this(Guid.NewGuid(), question, oneStar, twoStar, threeStar, fourStar, fiveStar)
        {
        }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
