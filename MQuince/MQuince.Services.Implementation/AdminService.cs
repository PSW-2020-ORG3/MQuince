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
    public class AdminService : IAdminService
    {
        public IUserRepository _userRepository;
        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository == null ? throw new ArgumentNullException(nameof(userRepository) + "is set to null") : userRepository;
        }

        public IEnumerable<IdentifiableDTO<AdminDTO>> GetAll()
        {
            try
            {
                return _userRepository.GetAllAdmins().Select(c => AdminMapper.MapAdminEntityToIdentifierAdminDTO(c));
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

        public IdentifiableDTO<AdminDTO> GetById(Guid id)
        {
            try
            {
                return AdminMapper.MapAdminEntityToIdentifierAdminDTO(_userRepository.GetAdminById(id));
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
