using BussinessObjects.Dtos.User;
using BussinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace APIControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            try
            {
                var u = await _userService.Login(request.Email, request.Password);
                if (u is not null)
                {
                    return Ok(u);
                }
                else
                {
                    return BadRequest("Don't have account!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserLoginResponse>> SignupAsync(UserLoginRequest request)
        {
            try
            {
                var u = await _userService.Signup(request.Email, request.Password);
                if (u is not null)
                {
                    return Ok(u);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
