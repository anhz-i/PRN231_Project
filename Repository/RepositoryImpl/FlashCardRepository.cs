using AutoMapper;
using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;

namespace Repositories.RepositoryImpl
{
    public class FlashCardRepository : IFlashCardRepository
    {
        private readonly QuizletProjectContext _context;
        
        public FlashCardRepository(QuizletProjectContext context, IMapper mapper)
        {
            _context = context;            
        }

        public async Task AddAsync(FlashCard entity)
        {
            try
            {
                await _context.FlashCards.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<FlashCard>> GetAllAsync()
        {
            try
            {
                return await _context.FlashCards.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<FlashCard?> GetByIdAsync(long id)
        {
            try
            {
                return await _context.FlashCards.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveAsync(FlashCard entity)
        {
            try
            {
                _context.FlashCards.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<FlashCard> entities)
        {
            try
            {
                _context.FlashCards.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(FlashCard entity)
        {
            try
            {
                _context.Entry<FlashCard>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateRange(IEnumerable<FlashCard> entities)
        {
            throw new NotImplementedException();
        }
    }
}
