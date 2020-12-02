using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class WorkTimeService : IWorkTimeService
    {
        IEnumerable<WorkTime> IWorkTimeService.GetWorkTimesForDoctor(Guid doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
