using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Models;

namespace Almostengr.Greenhouse.Api.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
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