using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Patient")]
    public class PatientPersistence : UserPersistence
    {
        public bool Guest { get; set; }
        //[ForeignKey("MedicalRecordId")]
        //public MedicalRecordPersistance MedicalRecordId { get; set; }
        [ForeignKey("ChosenDoctor")]
        public DoctorPersistence PersonalDoctor { get; set; }
    }
}
