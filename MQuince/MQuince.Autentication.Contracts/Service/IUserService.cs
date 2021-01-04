using MQuince.Autentication.Contracts.DTO;

namespace MQuince.Autentication.Contracts.Service
{
    public interface IUserService
    {
        public AuthenticateResponseDTO Login(LoginDTO loginDTO);
    }
}
