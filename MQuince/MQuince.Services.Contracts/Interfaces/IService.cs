using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IService<T, IdentifiableT> where T : class where IdentifiableT : class
    {
        IEnumerable<IdentifiableT> GetAll();
        IdentifiableT GetById(Guid id);
        Guid Create(T entityDTO);
        void Update(T entityDTO, Guid id);
        bool Delete(Guid id);
    }
}
