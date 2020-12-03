using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IDoctorService
    {
        IdentifiableDTO<DoctorDTO> GetById(Guid id);
        IEnumerable<IdentifiableDTO<DoctorDTO>> GetDoctorsPerSpecialization(Guid specializationId);
    }
}
