using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.Interfaces
{
    public interface IWorkTimeService
    {
        IEnumerable<WorkTime> GetWorkTimesForDoctor(Guid doctorId);
        WorkTime GetWorkTimeForDoctorForDate(Guid doctorId, DateTime date);
    }
}
