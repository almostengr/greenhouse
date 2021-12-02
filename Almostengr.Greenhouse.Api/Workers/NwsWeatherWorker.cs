using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api.Workers
{
    public class NwsWeatherWorker : BaseWorker
    {
        private readonly ILogger<NwsWeatherWorker> _logger;

        public NwsWeatherWorker(ILogger<NwsWeatherWorker> logger, ITwitterClient twitterClient) : base(logger, twitterClient)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
                // loop through weather locations and get their readings
                // save each reading to the database
            List<string> weatherStationIds = new();
            weatherStationIds.Add("https://api.weather.gov/stations/KMGM/observations/latest");

            while (!stoppingToken.IsCancellationRequested)
            {
                // foreach (var weatherStationUrl in weatherStationIds)
                // {
                //     var observation = await HttpGetAsync<NwsObservationDto>(_httpClient, weatherStationUrl);

                //     if (observation == null)
                //     {
                //         _logger.LogError($"Failed to get weather data from {weatherStationUrl}");
                //         continue;
                //     }

                //     try
                //     {
                //         var temperature = new Temperature(observation);
                //         await _temperatureRepository.AddAsync(temperature);
                //         await _temperatureRepository.SaveAsync();
                //     }
                //     catch (Exception ex)
                //     {
                //         _logger.LogError(ex, ex.Message);
                //     }

                //     try
                //     {
                //         var precipitation = new Precipitation(observation);
                //         await _precipitationRepository.AddAsync(precipitation);
                //         await _precipitationRepository.SaveAsync();
                //     }
                //     catch (Exception ex)
                //     {
                //         _logger.LogError(ex, ex.Message);
                //     }
                // }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}