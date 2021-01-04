using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Contracts.DTO;
using System;

namespace MQuince.StafManagement.Contracts.Interfaces
{
    public interface IPatientService
    {
        IdentifiableDTO<PatientDTO> GetById(Guid id);
    }
}
