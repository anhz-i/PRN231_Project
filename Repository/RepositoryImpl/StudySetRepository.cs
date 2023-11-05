using AutoMapper;
using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepositories;

namespace Repositories.RepositoryImpl
{
    public class StudySetRepository : IStudySetRepository
    {
        private readonly QuizletProjectContext _context;
        
        public StudySetRepository(QuizletProjectContext context, IMapper mapper)
        {
            _context = context;            
        }

        public async Task AddAsync(StudySet entity)
        {
            try
            {
                await _context.StudySets.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<StudySet>> GetAllAsync()
        {
            try
            {
                return await _context.StudySets.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<StudySet?> GetByIdAsync(long id)
        {
            try
            {
                return await _context.StudySets.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveAsync(StudySet entity)
        {
            try
            {
                _context.StudySets.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task RemoveRangeAsync(IEnumerable<StudySet> entities)
        {
            try
            {
                _context.StudySets.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(StudySet entity)
        {
            try
            {
                _context.Entry<StudySet>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateRange(IEnumerable<StudySet> entities)
        {
            throw new NotImplementedException();
        }
    }
}
