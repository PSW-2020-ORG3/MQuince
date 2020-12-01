using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.IntegrationMySQL.PersistenceEntities
{
    [Table("Pharmacy")]
    public class PharmacyPersistence
    {
        [Key]
        public Guid ApiKey { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }

        public PharmacyPersistence() { }
        
        public PharmacyPersistence(Guid apiKey, string name,string url)
        {
            ApiKey = apiKey;
            Name = name;
            Url = url;          

        }
            
       
    }
}
