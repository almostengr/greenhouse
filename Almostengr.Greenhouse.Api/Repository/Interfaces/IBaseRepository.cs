using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Models;
using Almostengr.Greenhouse.Api.Services.Interfaces;

namespace Almostengr.Greenhouse.Api.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel, IBaseService<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        // void Update(T entity);
        // void Delete(T entity);
        // void Delete(int id);
        Task SaveAsync();
    }
}