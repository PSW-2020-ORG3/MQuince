using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        public IEnumerable<WorkTime> GetWorkTimesForDoctor(Guid doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
