using System;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransferObjects;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;

namespace Almostengr.Greenhouse.Api.Sensors.Mock
{
    public class MockMoistureSensor : IMoistureSensor
    {
        public async Task<MoistureDto> IsSoilWet()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            
            Random rnd = new Random();

            return new MoistureDto { 
                SensorName = "MockMoistureSensor",
                MoistureLevel = rnd.Next(0, 100) > 50 ? 100 : 0,
            };
        }

        Task<MoistureDto> IMoistureSensor.IsSoilWet()
        {
            throw new NotImplementedException();
        }
    }
}