using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.Api.Services;
using Almostengr.WeatherStation.Api;
using Microsoft.Extensions.Hosting;

namespace Almostengr.GardenMgr.Irrigation.Api.Workers
{
    public class IrrigationWorker : BackgroundService
    {
        private readonly IIrrigationService _service;
        private readonly AppSettings _appSettings;

        public IrrigationWorker(IIrrigationService service, AppSettings appSettings)
        {
            _service = service;
            _appSettings = appSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var zone in _appSettings.Irrigation.Zones)
                {
                    // check zone sensor for moisture

                    // if moisture is low, check the water tank level

                    // if water tank level is above empty, then irrigate

                    // if water tank is empty, send alert to user
                }

                await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
            }
        }
    }
}