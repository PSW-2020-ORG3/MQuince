using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.Repository
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetAll();
    }
}
