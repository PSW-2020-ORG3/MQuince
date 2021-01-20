using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Sftp.Constracts.DTO
{
    public class MedicationsConsumptionDTO
    {

        public string Name { get; set; }
        public DateTime DateOfConsumtion { get; set; }

        public int Quantity { get; set; }

        public MedicationsConsumptionDTO()
        {

        }
    }
}
