using MQuince.Autentication.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Autentication.Contracts.Service
{
    public interface IUserService
    {
        public AuthenticateResponseDTO Login(LoginDTO loginDTO);
    }
}
