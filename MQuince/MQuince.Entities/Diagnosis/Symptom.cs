using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Diagnosis
{
    public class Symptom
    {
        private Guid _id;
        public string Name { get; set; }
        public List<Guid> DiagnosisId { get; set; }

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
