using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Database;
using Almostengr.Greenhouse.Api.Models;
using Almostengr.Greenhouse.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greehouse.Api.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly GreenhouseContext _context;

        protected BaseRepository(GreenhouseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}