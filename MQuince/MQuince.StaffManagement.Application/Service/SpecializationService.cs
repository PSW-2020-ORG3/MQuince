using MQuince.Core.IdentifiableDTO;
using MQuince.Infrastructure.DataProvider.Util;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using MQuince.StafManagement.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Application.Service
{
    public class SpecializationService : ISpecializationService
    {
        public ISpecializationRepository _specializationRepository;
        public SpecializationService(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository == null ? throw new ArgumentNullException(nameof(specializationRepository) + "is set to null") : specializationRepository;
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
