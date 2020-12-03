using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        public IdentifiableDTO<DoctorDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetDoctorsPerSpecialization(Guid specializationId)
        {
            throw new NotImplementedException();
        }
    }
}
