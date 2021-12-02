using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almostengr.Greenhouse.Api.Services.Interfaces
{
    public interface IBaseService
    {
        // IUnitOfWork UnitOfWork { get; }
        Task<bool> SaveChangesAsync();
        Task<IList<T>> GetAllAsync<T>() where T : class;
        Task<T> GetByIdAsync<T>(int id) where T : class;
    }
}