using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Common;
using Almostengr.Greenhouse.Scheduler.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Greenhouse.Scheduler.Workers
{
    public class AnalyticsWorker : BaseWorker
    {
        public readonly ILogger _logger;
        public readonly ITwitterClient _twitterClient;
        private readonly ITemperatureRepository _temperatureRepository;
        private readonly IPrecipitationRepository _precipitationRepository;

        public AnalyticsWorker(ILogger<AnalyticsWorker> logger, ITwitterClient twitterClient, AppSettings appSettings,
            ITemperatureRepository temperatureRepository, IPrecipitationRepository precipitationRepository) : 
            base(logger, twitterClient, appSettings)
        {
            _logger = logger;
            _twitterClient = twitterClient;
            _temperatureRepository = temperatureRepository;
            _precipitationRepository = precipitationRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime currentDateTime = DateTime.Now;

                if (currentDateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    await _temperatureRepository.GetLast7DaysReadingsAsync();        
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}