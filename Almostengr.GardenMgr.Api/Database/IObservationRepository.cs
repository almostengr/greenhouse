using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.Models;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Database
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