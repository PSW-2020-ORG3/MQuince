using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation.Util
{
    public class DoctorMapper
    {
        public static IdentifiableDTO<DoctorDTO> MapDoctorEntityToIdentifierDoctorDTO(Doctor doctor)
        {
            throw new NotImplementedException();
        }


        public static IEnumerable<IdentifiableDTO<DoctorDTO>> MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(IEnumerable<Doctor> doctors)
        {
            throw new NotImplementedException();
        }
    }
}
