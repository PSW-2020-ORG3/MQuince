using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Application.Services.Util;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using MQuince.StafManagement.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.StafManagement.Application.Service
{
    public class DoctorService : IDoctorService
    {
        public IUserRepository _userRepository;
        public DoctorService(IUserRepository userRepository)
        {
            _userRepository = userRepository == null ? throw new ArgumentNullException(nameof(userRepository) + "is set to null") : userRepository;
        }

        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll()
        {
            try
            {
                return _userRepository.GetAllDoctors().Select(c => DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(c));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }


        public IdentifiableDTO<DoctorDTO> GetById(Guid id)
        {
            try
            {
                return DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(_userRepository.GetDoctorById(id));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetDoctorsPerSpecialization(Guid specializationId)
        {
            try
            {
                return DoctorMapper.MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(_userRepository.GetDoctorsPerSpecialization(specializationId));
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }


    }
}
