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
        public IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<IdentifiableDTO<DoctorDTO>> GetAll()
            => _doctorRepository.GetAll().Select(c => DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(c));


        public IdentifiableDTO<DoctorDTO> GetById(Guid id)
        {
            try
            {
                return DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(_doctorRepository.GetById(id));
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
                return DoctorMapper.MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(_doctorRepository.GetDoctorsPerSpecialization(specializationId));
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
