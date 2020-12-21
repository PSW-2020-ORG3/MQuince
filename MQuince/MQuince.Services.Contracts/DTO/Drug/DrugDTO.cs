using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Drug
{
    public class DrugDTO
    {
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
        public Guid _whoApprovesDrug { get; set; }
        public List<Guid> AllergensId { get; set; }
        public List<Guid> IngredientsId { get; set; }
    }
}
