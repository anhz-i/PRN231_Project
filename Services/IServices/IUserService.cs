using BussinessObjects.Dtos.User;
using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserService
    {
        Task<UserLoginResponse> Login(string email, string password);
        Task<UserLoginResponse> Signup(string email, string password);
    }
}
