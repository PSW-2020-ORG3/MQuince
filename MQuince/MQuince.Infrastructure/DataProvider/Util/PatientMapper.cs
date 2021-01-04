
using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Infrastructure.DataProvider.Util
{
    public class PatientMapper
    {
        public static Patient MapPatientPersistenceToPatientEntity(PatientPersistence patientPersistance)
              => patientPersistance == null ? throw new ArgumentNullException()
                                            : new Patient()
                                            {
                                                Id=patientPersistance.Id,
                                                Name=patientPersistance.Name,
                                                Surname=patientPersistance.Surname,
                                                Username=patientPersistance.Username,
                                                Password=patientPersistance.Password,
                                                Guest=patientPersistance.Guest,
                                                Jmbg=patientPersistance.Jmbg,
                                                PersonalDoctor=patientPersistance.DoctorPersistanceId                                           
                                            };

        public static IEnumerable<Patient> MapPatientPersistenceCollectionToPatientEntityCollection(IEnumerable<PatientPersistence> patients)
                  => patients == null ? throw new ArgumentNullException()
                                             : patients.Select(entity => MapPatientPersistenceToPatientEntity(entity));
    }
}
