using APIControllers.JwtFeatures;
using BussinessObjects.Dtos.User;
using BussinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System.IdentityModel.Tokens.Jwt;

namespace APIControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtHandler _jwtHandler;

        public UserController(IUserService userService, JwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            try
            {
                var u = await _userService.Login(request.Email, request.Password);
                if (u is not null)
                {
                    var signingCredentials = _jwtHandler.GetSigningCredentials();
                    var claims = _jwtHandler.GetClaims(u);
                    var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    u.IsAuthSuccessful = true;
                    u.Token = token;
                    return Ok(u);                    
                }
                else
                {
                    return Unauthorized(new UserLoginResponse { ErrorMessage = "Invalid Authentication" });
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
