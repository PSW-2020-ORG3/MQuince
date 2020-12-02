using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MQuince.Entities;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepositoty)
        {
            _userRepository = userRepositoty;
        }

        public IEnumerable<IdentifiableDTO<UserDTO>> GetAll()
            => _userRepository.GetAll().Select(c => CreateUserDTO(c)); 


        public IdentifiableDTO<UserDTO> GetById(Guid id)
            => CreateUserDTO(_userRepository.GetById(id));


        private IdentifiableDTO<UserDTO> CreateUserDTO(User user)
        {
            if (user == null) return null;

            return new IdentifiableDTO<UserDTO>() { Id = user.Id, EntityDTO = new UserDTO() { Username = user.Username, 
                Jmbg = user.Jmbg,
                Name = user.Name, Password = user.Password,
                Surname = user.Surname  } };
        }

        private User CreateUserFromDTO(UserDTO user, Guid? id = null)
            => id == null ? new User(user.Username, user.Password, user.Jmbg, user.Name, user.Surname)
                          : new User(id.Value, user.Username, user.Password, user.Jmbg, user.Name, user.Surname);

        public Guid Create(UserDTO entityDTO)
        {
            User user = CreateUserFromDTO(entityDTO);
            _userRepository.Create(user);
            return user.Id;
        }

        private bool IsJmbgUnique(UserDTO entityDTO)
            => GetAll().SingleOrDefault(x => x.EntityDTO.Jmbg == entityDTO.Jmbg) == null;
    }
}
