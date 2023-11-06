using BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<User> FindByEmailAndPasswordAsync(string email, string password);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByUserAsync(string email);
    }
}
