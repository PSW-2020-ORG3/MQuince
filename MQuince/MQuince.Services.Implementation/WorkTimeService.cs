using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
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
        public IWorkTimeRepository _worktimeRepository;
        public WorkTimeService(IWorkTimeRepository worktimeRepository)
        {
            _worktimeRepository = worktimeRepository;
        }
        IEnumerable<WorkTime> IWorkTimeService.GetWorkTimesForDoctor(Guid doctorId)
                                    => _worktimeRepository.GetWorkTimesForDoctor(doctorId);
    }
}
