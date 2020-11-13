using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.IdentifiableDTO
{
    public class IdentifiableDTO<T> where T : class
    {   
        public Guid Id { get; set; }

        public T EntityDTO { get; set; }
        
    }
}
