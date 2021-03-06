﻿using System;

namespace MQuince.Pharmacy.Domain
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
    }
}
