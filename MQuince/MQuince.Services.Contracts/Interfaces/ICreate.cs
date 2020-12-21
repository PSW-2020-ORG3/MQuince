using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface ICreate<T> where T : class
    {
        Guid Create(T entityDTO);
    }
}
