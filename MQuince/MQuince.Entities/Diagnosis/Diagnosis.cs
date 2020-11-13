using System;
using System.Collections.Generic;
using MQuince.Entities.Drug;
using System.Dynamic;
using System.Text;

namespace MQuince.Entities.Diagnosis
{
    public class Diagnosis
    {
        private Guid _id;
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Theraphy { get; set; }
        public List<Guid> SymptomsId = new List<Guid>();
        public List<Guid> TheraphyDrugsId = new List<Guid>();
        public string DoctorCreated { get; set; }

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
