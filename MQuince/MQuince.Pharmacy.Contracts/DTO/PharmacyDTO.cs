using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Pharmacy.Contracts.DTO
{
	public class PharmacyDTO
	{
        public Guid ApiKey { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }
        public PharmacyDTO(Guid apiKey, string name, string url)
        {

            if (apiKey == Guid.Empty)
            {
                throw new ArgumentException("Argument can not be Guid.Empty");
            }
            else
            {
                ApiKey = apiKey;
                Name = name;
                Url = url;
            }

        }
        public PharmacyDTO()
        {

        }
    }
}
