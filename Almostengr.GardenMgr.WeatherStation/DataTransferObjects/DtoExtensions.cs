using Almostengr.GardenMgr.Common.Models;

namespace Almostengr.GardenMgr.WeatherStation.DataTransferObjects
{
    public static class DtoExtensions
    {
        public static Observation ToObservation(this ObservationDto observationDto)
        {
            return new Observation{

            };
        }
    }   
}