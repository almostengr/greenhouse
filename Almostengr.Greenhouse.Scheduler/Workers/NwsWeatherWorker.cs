using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Common;
using Almostengr.Greenhouse.Scheduler.DataTransferObject;
using Almostengr.Greenhouse.Scheduler.Models;
using Almostengr.Greenhouse.Scheduler.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Scheduler.Workers
{
    public class NwsWeatherWorker : BaseWorker
    {
        public readonly AppSettings _appSettings;
        private readonly IPrecipitationRepository _precipitationRepository;
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly ILogger<NwsWeatherWorker> _logger;
        private HttpClient _httpClient;

        public NwsWeatherWorker(ILogger<NwsWeatherWorker> logger, ITwitterClient twitterClient, AppSettings appSettings,
            IPrecipitationRepository precipitationRepository, ITemperatureRepository temperatureRepository) :
            base(logger, twitterClient, appSettings)
        {
            _appSettings = appSettings;
            _precipitationRepository = precipitationRepository;
            _temperatureRepository = temperatureRepository;
            _logger = logger;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            List<string> weatherStationIds = new();
            weatherStationIds.Add("https://api.weather.gov/stations/KMGM/observations/latest");

            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var weatherStationUrl in weatherStationIds)
                {
                    var observation = await HttpGetAsync<NwsObservationLatestDto>(_httpClient, weatherStationUrl);

                    if (observation == null)
                    {
                        _logger.LogError($"Failed to get weather data from {weatherStationUrl}");
                        continue;
                    }

                    try
                    {
                        var temperature = new Temperature(observation);
                        await _temperatureRepository.AddAsync(temperature);
                        await _temperatureRepository.SaveAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }

                    try
                    {
                        var precipitation = new Precipitation(observation);
                        await _precipitationRepository.AddAsync(precipitation);
                        await _precipitationRepository.SaveAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, ex.Message);
                    }
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}