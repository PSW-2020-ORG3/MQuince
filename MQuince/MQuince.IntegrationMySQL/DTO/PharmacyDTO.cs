using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.IntegrationMySQL.DTO
{
    public class PharmacyDTO
    {
        
        public Guid ApiKey { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }
        public PharmacyDTO()
        {
        }
    }

    
}
