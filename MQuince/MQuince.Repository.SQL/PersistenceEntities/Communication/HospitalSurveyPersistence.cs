using MQuince.Entities.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Communication
{
    [Table("HospitalSurvey")]
    public class HospitalSurveyPersistence
    {
        [Key]
        public Guid Id { get; set; }
        
        public int OneStar { get; set; }
        public int TwoStar { get; set; }
        public int ThreeStar { get; set; }
        public int FourStar { get; set; }
        public int FiveStar { get; set; }
        public QuestionPersistence Question { get; set; }
    }
}
