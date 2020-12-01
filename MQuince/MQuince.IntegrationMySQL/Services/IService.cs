using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.IntegrationMySQL.Services
{
    public interface IService<T, IdentifiableT> where T : class where IdentifiableT : class
    {
        IEnumerable<IdentifiableT> GetAll();
        IdentifiableT GetByApi(Guid id);
        Guid Create(T entityDTO);
        void Update(T entityDTO, Guid id);
        bool Delete(Guid id);
    }
}
