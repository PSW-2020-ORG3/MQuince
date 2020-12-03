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
              => doctorPersistence == null ? throw new ArgumentNullException()
                                        : new Doctor()
                                        {
                                            Id = doctorPersistence.Id,
                                            Name = doctorPersistence.Name,
                                            Surname = doctorPersistence.Surname,
                                            Username = doctorPersistence.Username,
                                            Password = doctorPersistence.Password,
                                            Jmbg = doctorPersistence.Jmbg,
                                            Biography = doctorPersistence.Biography,
                                            SpecializationId = doctorPersistence.SpecializationId
                                        };


        public static IEnumerable<Doctor> MapDoctorPersistenceCollectionToDoctorEntityCollection(IEnumerable<DoctorPersistence> doctorPersistances)
              => doctorPersistances == null ? throw new ArgumentNullException()
                                         : doctorPersistances.Select(entity => MapDoctorPersistenceToDoctorEntity(entity));

    }
}
