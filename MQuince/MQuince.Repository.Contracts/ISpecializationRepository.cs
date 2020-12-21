﻿using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetAll();
    }
}
