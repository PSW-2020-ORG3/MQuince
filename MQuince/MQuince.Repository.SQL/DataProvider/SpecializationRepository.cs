using System;
using System.Collections.Generic;
using MQuince.Repository.Contracts;
using System.Text;
using MQuince.Entities.Users;
using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.DataAccess;

namespace MQuince.Repository.SQL.DataProvider
{
    public class SpecializationRepository : ISpecializationRepository
    {
        public IEnumerable<Specialization> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
