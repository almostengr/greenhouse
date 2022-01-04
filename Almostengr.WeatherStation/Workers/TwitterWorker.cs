using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Services.Interface;

namespace Almostengr.WeatherStation.Workers
{
    public class TwitterWorker : BaseWorker
    {
        public readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;

        public TwitterWorker(AppSettings appSettings, IObservationService observationService)
        {
            _appSettings = appSettings;
            _observationService = observationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                // read latest row from the database
                var observationDto = await _observationService.GetLatestObservationAsync();

                // post to twitter

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.Twitter.UpdateInterval), stoppingToken);
            }
        }
    }
}