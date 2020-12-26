using MQuince.Entities;
using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class AuthenticateResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public UserRole UserRole { get; set; }
        public string Token { get; set; }

        public AuthenticateResponseDTO(User user, string token)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Username = user.Username;
            this.Token = token;
            if (user.GetType() == typeof(Admin))
            {
                UserRole = UserRole.Admin;
            }
            else
            {
                UserRole = UserRole.Patient;
            }
        }
    }
}
