﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MQuince.IntegrationMySQL.Repository
{
    public interface IRepository<T> where T : class
    {
        

        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        bool Delete(Guid id);
    }
}
