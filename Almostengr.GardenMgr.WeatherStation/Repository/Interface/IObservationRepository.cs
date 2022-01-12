using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Api.DataTransferObjects;
using Almostengr.WeatherStation.Api.Models;

namespace Almostengr.WeatherStation.Api.Repository.Interface
{
    public interface IObservationRepository : IBaseRepository
    {
        Task CreateObservationAsync(Observation observation);
        Task<List<ObservationDto>> GetAllObservationsAsync();
        Task<ObservationDto> GetByObservationIdAsync(int observationId);
        Task<ObservationDto> GetLatestObservationAsync();
        void DeleteObservations(List<Observation> observations);
        Task<List<Observation>> GetObservationsOlderThanDate(DateTime date);
    }
}