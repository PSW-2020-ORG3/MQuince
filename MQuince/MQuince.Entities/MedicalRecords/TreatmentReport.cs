using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class TreatmentReport
    {
        private Guid _id;
        public string Anamnesis { get; set; }
        public string Note { get; set; }
        public string Diagnosis { get; set; }
        public string Theraphy { get; set; }
        public Guid PatientId { get; set; }
        public Guid PrescriptionId { get; set; }
        public List<Guid> RefferalId = new List<Guid>();

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
