using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation.Util
{
    public class PatientMapper
    {
        public static IdentifiableDTO<PatientDTO> MapPatientEntityToPatientIdentifierDTO(Patient patient)
                => patient == null ? throw new ArgumentNullException()
                                            : new IdentifiableDTO<PatientDTO>()
                                            {
                                                Id = patient.Id,
                                                EntityDTO = new PatientDTO()
                                                {
                                                    Name=patient.Name,
                                                    Surname = patient.Surname,
                                                    Username = patient.Username,
                                                    Password = patient.Password,
                                                    Guest = patient.Guest,
                                                    Jmbg = patient.Jmbg,
                                                    PersonalDoctor = patient.PersonalDoctor
                                                }
                                            };
    }
}
