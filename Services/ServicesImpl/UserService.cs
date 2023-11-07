using AutoMapper;
using BussinessObjects.Dtos.User;
using BussinessObjects.Models;
using Repositories.IRepositories;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginResponse> Login(string email, string password)
        {
            try
            {
                var u = await _userRepository.FindByEmailAsync(email);
                if (u is null)
                {
                    throw new Exception("Email existed");
                }
                u = await _userRepository.FindByEmailAndPasswordAsync(email, password);
                if (u is not null)
                {
                    return _mapper.Map<UserLoginResponse>(u);
                }
                else
                {
                    throw new Exception("Password is incorrect");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<UserLoginResponse> Signup(string email, string password)
        {
            try
            {
                var checkEmail = await _userRepository.FindByEmailAsync(email);
                if (checkEmail is not null)
                {
                    throw new Exception("Email existed!");
                }
                var user = new User();
                user.Email = email;
                user.Password = password;
                user.Username = email.Substring(0, email.IndexOf('@'));
                await _userRepository.AddAsync(user);
                return _mapper.Map<UserLoginResponse>(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
