using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Drug
{
    public class Allergen
    {
        private Guid _id;
        public string Name { get; set; }
        public Allergen(Guid id, String name)
        {
            _id = id;
            Name = name;
        }

        public Allergen(String name):this(Guid.NewGuid(), name)
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
