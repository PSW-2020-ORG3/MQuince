using MQuince.StafManagement.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using MQuince.StafManagement.Contracts.Repository;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Application.Service
{
    public class WorkTimeService : IWorkTimeService
    {
        public IWorkTimeRepository _worktimeRepository;
        public WorkTimeService(IWorkTimeRepository worktimeRepository)
        {
            _worktimeRepository = worktimeRepository == null ? throw new ArgumentNullException(nameof(worktimeRepository) + "is set to null") : worktimeRepository;
        }
        public IEnumerable<WorkTime> GetWorkTimesForDoctor(Guid doctorId)
        {
            try
            {
                return _worktimeRepository.GetWorkTimesForDoctor(doctorId);
            }
            catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }
        public WorkTime GetWorkTimeForDoctorForDate(Guid doctorId, DateTime date)
		{
            foreach(WorkTime workTime in GetWorkTimesForDoctor(doctorId))
			{
                if(date.Date >= workTime.StartDate.Date && date.Date <= workTime.EndDate.Date)
				{
                    return new WorkTime(workTime.Id, date, date, workTime.StartTime, workTime.EndTime, doctorId);
				}
			}
            return null;
        }

	}
}
