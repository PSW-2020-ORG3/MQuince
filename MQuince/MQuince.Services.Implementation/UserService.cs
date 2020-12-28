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


        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository == null ? throw new ArgumentNullException(nameof(userRepository) + "is set to null") : userRepository;
        }

        

        public AuthenticateResponseDTO Login(LoginDTO loginDTO)
        {
            var user = this.TryLogin(loginDTO);

            try
            {
                string token = GenerateJwtToken(user);
                
                return new AuthenticateResponseDTO(user, token);
            }catch(Exception e)
            {
                throw new InternalServerErrorException();
            }
            
        }

        private User TryLogin(LoginDTO loginDTO)
        {
            var user = this.GetPatientFromLoginDTO(loginDTO);

            if (user == null)
            {
                user = this.GetAdminFromLoginDTO(loginDTO);
            }

            if (user==null)
                throw new NotFoundEntityException();

            return user;
        }

        private User GetAdminFromLoginDTO(LoginDTO loginDTO)
        {
            try
            {
                return _userRepository.GetAllAdmins().SingleOrDefault(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password);
            }
            catch (Exception e)
            {
                throw new InternalServerErrorException();
            }
        }

        private User GetPatientFromLoginDTO(LoginDTO loginDTO)
        {
            try
            {
                return _userRepository.GetAllPatients().SingleOrDefault(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password);
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

                Expires = DateTime.UtcNow.AddDays(7), // mnogo je 7 dana :D

                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string DecodeJWTToken(string token)
        {
            string secret = "SECMQUINCEAPPNKSGGASR5323";
            var key = Encoding.ASCII.GetBytes(secret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            return claims.Identity.Name;
        }
    }
}
