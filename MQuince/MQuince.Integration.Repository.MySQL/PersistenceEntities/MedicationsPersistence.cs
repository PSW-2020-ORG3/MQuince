using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.PersistenceEntities
{
    public class MedicationsPersistence
    {
        [Key]
        public Guid KeyMedication { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
       
        public int Quantity { get; set; }

        public MedicationsPersistence() { }

        public MedicationsPersistence(Guid key, string name, int quantity)
        {
            this.KeyMedication = key;
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}
