using MQuince.Entities.Rooms;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class HospitalTreatment : Refferal
    {
        private Guid _id;
        public DateTime Date { get; set; }
        public DateTime DateTo { get; set; }
        public string Note { get; set; }
        public bool Completed { get; set; }
        public Guid PatientId { get; set; }
        public Guid RoomId { get; set; }
        public Guid SectorId { get; set; }


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
