using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Integration.Infrastructure.PersistenceEntities
{
    [Table("MedicationsConsumption")]
    public class MedicationsConsumptionPersistance
    {
        [Key]
        public Guid KeyConsumtion { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfConsumtion { get; set; }
        [Required]
        public int Quantity { get; set; }

        public MedicationsConsumptionPersistance() { }

        public MedicationsConsumptionPersistance(Guid key, string name, DateTime date, int quantity)
        {
            this.KeyConsumtion = key;
            this.Name = name;
            this.DateOfConsumtion = date;
            this.Quantity = quantity;
        }
    }
}
