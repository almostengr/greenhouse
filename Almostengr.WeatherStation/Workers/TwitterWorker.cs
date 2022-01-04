using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Almostengr.WeatherStation.Workers
{
    public class TwitterWorker : BaseWorker
    {
        public readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;

        public TwitterWorker(AppSettings appSettings, IServiceScopeFactory factory)
        {
            _appSettings = appSettings;
            _observationService = factory.CreateScope().ServiceProvider.GetRequiredService<IObservationService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var observationDto = await _observationService.GetLatestObservationAsync();

                // post to twitter

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.Twitter.UpdateInterval), stoppingToken);
            }
        }
    }
}