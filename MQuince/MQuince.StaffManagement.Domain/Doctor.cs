using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Domain
{
    public class Doctor : Staff
    {
        public string Biography { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
