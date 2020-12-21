using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class CityDTO
    {
        public string Name { get; set; }
        public int PostNumber { get; set; }
        public Guid CountryId { get; set; }
    }
}
