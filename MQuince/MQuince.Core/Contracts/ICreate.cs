using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Core.Contracts
{
    public interface ICreate<T> where T : class
    {
        void Create(T entity);
    }
}
