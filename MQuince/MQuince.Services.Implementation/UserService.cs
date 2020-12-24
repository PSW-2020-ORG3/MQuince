using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using MQuince.Entities;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class UserService : IUserService
    {

        private readonly IPatientRepository _patientRepository;

        public UserService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository == null ? throw new ArgumentNullException(nameof(patientRepository) + "is set to null") : patientRepository;
        }

        public AuthenticateResponseDTO Login(LoginDTO loginDTO)
        {
            var user = this.GetPatientFromLoginDTO(loginDTO);

            if (user == null)
            {
                user = null; //_administratorRepository...
                if (user == null)
                    throw new NotFoundEntityException();
            }

            try
            {
                string token = GenerateJwtToken(user);

                return new AuthenticateResponseDTO(user, token);
            }catch(Exception e)
            {
                throw new InternalServerErrorException();
            }
            
        }

        private User GetPatientFromLoginDTO(LoginDTO loginDTO)
        {
            try
            {
                return _patientRepository.GetAll().SingleOrDefault(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password);
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECURITASKEYINMQUINCEALLIANCETEST123 phase"));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
