using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class AdressDTO
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public Guid CityId { get; set; }
    }
}
