using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class MyPharmacy
    {
        public Guid ApiKey { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public MyPharmacy()
        {

        }

        public MyPharmacy(Guid apiKey, string name, string url)
        {
            ApiKey = apiKey;
            Name = name;
            Url = url;

        }
    }
}
