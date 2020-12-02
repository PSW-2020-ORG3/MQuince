using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IWorkTimeRepository
    {
        IEnumerable<WorkTime> GetWorkTimesForDoctor(Guid doctorId);
    }
}
