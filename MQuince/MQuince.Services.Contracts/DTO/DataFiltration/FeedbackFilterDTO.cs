using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataFiltration
{
    public class FeedbackFilterDTO
    {
        private Guid _doctorId;
        public double AverageGradeFrom { get; set; }
        public double AverageGradeTo { get; set; }

        public Guid Id
        {
            get { return _doctorId; }
            private set
            {
                _doctorId = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

    }
}
