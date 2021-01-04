
using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Infrastructure.DataProvider.Util
{
    public class WorkTimeMapper
    {
        public static WorkTime MapWorkTimePersistenceToWorkTimeEntity(WorkTimePersistence workTimePersistance)
              => workTimePersistance == null ? throw new ArgumentNullException()
                                        : new WorkTime(workTimePersistance.StartDate, workTimePersistance.EndDate, workTimePersistance.StartTime, workTimePersistance.EndTime, workTimePersistance.DoctorId);

        public static IEnumerable<WorkTime> MapWorkTimePersistenceCollectionToWorkTimeEntityCollection(IEnumerable<WorkTimePersistence> workTimes)
              => workTimes == null ? throw new ArgumentNullException()
                                         : workTimes.Select(entity => MapWorkTimePersistenceToWorkTimeEntity(entity));
    }
}
