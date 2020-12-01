using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.IntegrationMySQL.DTO
{
    public class IdentifiableDTO<T> where T : class
    {
        public Guid Key { get; set; }
        public T EntityDTO{ get; set; }

    }
}
