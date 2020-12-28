using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class Tender
    {
        private Guid _id;

        public string Name { get; set; }

        public string Descritpion { get; set; }
        
        public string FormLink { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Boolean Opened { get; set; }

        public Tender(string name, string descritpion, string formLink, DateTime startDate, DateTime endDate,Boolean opened)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be empty");
            }
            else
            {
                Name = name;
                Descritpion = descritpion;
                FormLink = formLink;
                StartDate = startDate;
                EndDate = endDate;
                Opened = opened;
            }

        }
        public Tender(Guid id,string name, string descritpion, string formLink, DateTime startDate, DateTime endDate,Boolean opened)
        {

                _id = id;
                Name = name;
                Descritpion = descritpion;
                FormLink = formLink;
                StartDate = startDate;
                EndDate = endDate;
                Opened = opened;
            

        }
        public Tender(string name, string descritpion, string formLink, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be empty");
            }
            else
            {
                Name = name;
                Descritpion = descritpion;
                FormLink = formLink;
                StartDate = startDate;
                EndDate = endDate;
            }

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
