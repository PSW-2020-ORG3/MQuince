using Microsoft.AspNetCore.Mvc;
using MQuince.Autentication.Contracts.DTO;
using MQuince.Autentication.Contracts.Exceptions;
using MQuince.Autentication.Contracts.Service;

namespace MQuince.Autentication.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController([FromServices] IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                var response = _userService.Login(loginDTO);

                return Ok(response);
            }
            catch (EntityNotFoundException)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            catch (InternalServerErrorException)
            {
                return StatusCode(500);
            }


        }
    }
}
