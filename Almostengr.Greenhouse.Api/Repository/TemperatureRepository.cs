using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Repository.Interfaces;

namespace Almostengr.Greenhouse.Api.Repository
{
    public class TemperatureRepository : ITemperatureRepository
    {
        public TemperatureRepository()
        {
        }

        public async Task<IList<TemperatureDto>> GetAllAsync<TemperatureDto>() where TemperatureDto : class
        {
            throw new System.NotImplementedException();
        }

        public async Task<TemperatureDto> GetByIdAsync<TemperatureDto>(int id) where TemperatureDto : class
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TemperatureDto>> GetLast1DaysReadingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TemperatureDto>> GetLast30DaysReadingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TemperatureDto>> GetLast365DaysReadingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TemperatureDto>> GetLast7DaysReadingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<TemperatureDto>> GetLast90DaysReadingsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }   
}