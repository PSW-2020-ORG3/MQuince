using Microsoft.IdentityModel.Tokens;
using MQuince.Autentication.Contracts.DTO;
using MQuince.Autentication.Contracts.Exceptions;
using MQuince.Autentication.Contracts.Repository;
using MQuince.Autentication.Contracts.Service;
using MQuince.Autentication.Domain;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MQuince.Autentication.Application.Services
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
            }
            catch (Exception)
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

            if (user == null)
                throw new EntityNotFoundException();

            return user;
        }

        private User GetAdminFromLoginDTO(LoginDTO loginDTO)
        {
            try
            {
                return _userRepository.GetAllAdmins().SingleOrDefault(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password);
            }
            catch (Exception)
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
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECURITASKEYINMQUINCEALLIANCETEST123 phase"));

            UserRole userRole = GetUserRole(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Sid, user.Id.ToString()), new Claim(ClaimTypes.Role, userRole.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private UserRole GetUserRole(User user)
        {
            if (user.GetType() == typeof(Admin))
                return UserRole.Admin;
            else
                return UserRole.Patient;

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
