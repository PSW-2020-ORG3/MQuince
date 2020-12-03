using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class DoctorMapper
    {
        public static Doctor MapDoctorPersistenceToDoctorEntity(DoctorPersistence doctorPersistence)
        {
            throw new NotImplementedException();
        }


        public static IEnumerable<Doctor> MapDoctorPersistenceCollectionToDoctorEntityCollection(IEnumerable<DoctorPersistence> doctorPersistances)
        {
            throw new NotImplementedException();
        }
      
    }
}
