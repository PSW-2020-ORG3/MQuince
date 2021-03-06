﻿
using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.StafManagement.Application.Services.Util
{
    public class DoctorMapper
    {
        public static IdentifiableDTO<DoctorDTO> MapDoctorEntityToIdentifierDoctorDTO(Doctor doctor)
                => doctor == null ? throw new ArgumentNullException()
                                        : new IdentifiableDTO<DoctorDTO>()
                                        {
                                            Id = doctor.Id,
                                            EntityDTO = new DoctorDTO()
                                            {
                                                Name= doctor.Name,
                                                Surname = doctor.Surname,
                                                Username = doctor.Username,
                                                Password = doctor.Password,
                                                Jmbg = doctor.Jmbg,
                                                Biography = doctor.Biography,
                                                Specialization = doctor.SpecializationId
                                            }
                                            
                                        };


        public static IEnumerable<IdentifiableDTO<DoctorDTO>> MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(IEnumerable<Doctor> doctors)
                    => doctors == null ? throw new ArgumentNullException()
                                         : doctors.Select(entity => MapDoctorEntityToIdentifierDoctorDTO(entity));
    }
}
