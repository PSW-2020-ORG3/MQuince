using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Drug
{
    public class Drug
    {
        private Guid _id;
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

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

        public Guid WhoApprovesDrug
        {
            get { return _whoApprovesDrug; }
            private set
            {
                _whoApprovesDrug = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(WhoApprovesDrug)) : value;
            }
        }
    }
}
