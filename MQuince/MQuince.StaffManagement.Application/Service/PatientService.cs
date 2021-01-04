
using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Application.Services.Util;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using MQuince.StafManagement.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Application.Service
{
    public class PatientService : IPatientService
    {
        public IUserRepository _userRepository;
        public PatientService(IUserRepository userRepository)
        {
            _userRepository = userRepository == null ? throw new ArgumentNullException(nameof(userRepository) + "is set to null") : userRepository;
        }
        public IdentifiableDTO<PatientDTO> GetById(Guid id)
        {
            try
            {
                return PatientMapper.MapPatientEntityToPatientIdentifierDTO(_userRepository.GetPatientById(id));
            }
            catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

    }
}
