using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class DoctorSurvey
    {
        private Guid _id;
        public Doctor Doctor { get; set; }
        public Question Question { get; set; }
        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        public int FiveStar { get; set; }

        public DoctorSurvey() { }
        public DoctorSurvey(Guid id, Doctor doctor, Question question, int oneStar, int twoStar, int threeStar, int fourStar, int fiveStar)
        {
            _id = id;
            Doctor = doctor;
            Question = question;
            OneStar = oneStar;
            TwoStar = twoStar;
            ThreeStar = threeStar;
            FourStar = fourStar;
            FiveStar = fiveStar;
        }
        public DoctorSurvey(Question question, Doctor doctor, int oneStar, int twoStar, int threeStar, int fourStar, int fiveStar) :
            this(Guid.NewGuid(), doctor, question, oneStar, twoStar, threeStar, fourStar, fiveStar)
        {
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
