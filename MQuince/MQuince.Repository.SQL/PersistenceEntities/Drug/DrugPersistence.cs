using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Drug
{
    [Table("Drug")]
    public class DrugPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public double Quantity { get; set; }
        public string SideEffect { get; set; }
        public Formatdrug Format { get; set; }
        public string Instruction { get; set; }
        public int Amount { get; set; }
        public string Manufacturer { get; set; }
        public DrugStatus Status { get; set; }
        public string RejectReason { get; set; }
        [ForeignKey("_whoApprovesDrug")]
        public Guid _whoApprovesDrug { get; set; }
        [ForeignKey("AllergensId")]
        public List<Guid> AllergensId { get; set; }
        [ForeignKey("IngredientsId")]
        public List<Guid> IngredientsId { get; set; }
    }
}
