using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Repository.Interfaces;
using Almostengr.Greenhouse.Api.Services.Interfaces;

namespace Almostengr.Greenhouse.Api.Services
{
    public class MockTemperatureService : ITemperatureService
    {
        private readonly ITemperatureRepository _repository;

        public MockTemperatureService(ITemperatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TemperatureDto>> GetReadingForPeriodOfDaysAsync(int days)
        {
            return await _repository.GetReadingForPeriodOfDaysAsync(days);
        }

        public Task<TemperatureDto> GetTemperatureByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TemperatureDto>> GetTemperaturesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}