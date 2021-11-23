using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Database;
using Almostengr.Greenhouse.Scheduler.Models;
using Almostengr.Greenhouse.Scheduler.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Scheduler.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly GreenhouseContext _dbContext;

        protected BaseRepository(GreenhouseContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task<int> CountAll()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}