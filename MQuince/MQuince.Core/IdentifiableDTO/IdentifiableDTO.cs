using System;

namespace MQuince.Core.IdentifiableDTO
{
    public class IdentifiableDTO<T> where T : class
    {
        public Guid Id { get; set; }

        public T EntityDTO { get; set; }

    }
}
