using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class SpecializationService : ISpecializationService
    {
        public ISpecializationRepository _specializationRepository;
        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }
        public IEnumerable<IdentifiableDTO<SpecializationDTO>> GetAll()
        {
            try
            {
                return SpecializationMapper.MapSpecializationEntityCollectionToSpecializationIdentifierDTOCollection(_specializationRepository.GetAll());
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
