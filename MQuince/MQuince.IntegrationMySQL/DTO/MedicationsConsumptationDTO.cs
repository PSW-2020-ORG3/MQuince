using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.IntegrationMySQL.DTO
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
