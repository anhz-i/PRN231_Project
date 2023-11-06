using AutoMapper;
using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;

namespace Repositories.RepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizletProjectContext _context;
        
        public UserRepository(QuizletProjectContext context)
        {
            _context = context;            
        }

        public async Task AddAsync(User entity)
        {
            try
            {
                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> FindByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(i => i.Email.ToLower().Equals(email.ToLower()) && i.Password.Equals(password));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(i => i.Email.ToLower().Equals(email.ToLower()));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> FindByUserAsync(string username)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(i => i.Username.ToLower().Equals(username.ToLower()));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveAsync(User entity)
        {
            try
            {
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<User> entities)
        {
            try
            {
                _context.Users.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(User entity)
        {
            try
            {
                _context.Entry<User>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }
    }
}
