using MQuince.Autentication.Contracts.DTO;
using MQuince.Autentication.Domain;
using MQuince.Core.IdentifiableDTO;
using System;

namespace MQuince.Autentication.Application.Services.Util
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
                                                    Name = patient.Name,
                                                    Surname = patient.Surname,
                                                    Username = patient.Username,
                                                    Password = patient.Password,
                                                    Guest = patient.Guest,
                                                    Jmbg = patient.Jmbg,
                                                    PersonalDoctor = patient.PersonalDoctor ?? Guid.Empty
                                                }
                                            };
    }
}
