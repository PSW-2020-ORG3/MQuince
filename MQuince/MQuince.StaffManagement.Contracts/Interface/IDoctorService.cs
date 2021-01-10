using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.Interfaces
{
    public interface IDoctorService
    {
        IdentifiableDTO<DoctorDTO> GetById(Guid id);
        IEnumerable<IdentifiableDTO<DoctorDTO>> GetDoctorsPerSpecialization(Guid specializationId);
        IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll();
    }
}
