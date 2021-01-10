using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.IdentifiableDTO
{
    public class IdentifiableDTO<T> where T : class
    {
        public Guid Key { get; set; }
        public Boolean IsApproved { get; set; }
        public T EntityDTO { get; set; }

    }
}
