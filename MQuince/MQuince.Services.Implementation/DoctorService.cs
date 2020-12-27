using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation
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
            catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }


        public IdentifiableDTO<DoctorDTO> GetById(Guid id)
        {
            try
            {
                return DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(_userRepository.GetDoctorById(id));
            }catch(ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }catch(Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetDoctorsPerSpecialization(Guid specializationId)
        {
            try
            {
                return DoctorMapper.MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(_userRepository.GetDoctorsPerSpecialization(specializationId));
            }catch (ArgumentNullException e)
            {
                throw new NotFoundEntityException();
            }catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }


    }
}
