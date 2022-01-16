using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Relays
{
    public class MockPlantWateringRelay : MockBaseRelay, IPlantWateringRelay
    {
        private readonly ILogger<MockPlantWateringRelay> _logger;

        public MockPlantWateringRelay(ILogger<MockPlantWateringRelay> logger) : base(logger)
        {
            _logger = logger;
        }

        public void TurnOffWater(int waterGpioNumber, int pumpGpioNumber)
        {
            _logger.LogInformation($"Turning off water");
        }

        public void TurnOnWater(int waterGpioNumber, int pumpGpioNumber)
        {
            _logger.LogInformation("Turning on water");
        }

        public void CloseGpio(int gpioNumber)
        {
            _logger.LogInformation($"Closing GPIO {gpioNumber}");
        }

        public void OpenGpio(int gpioNumber)
        {
            _logger.LogInformation($"Opening GPIO {gpioNumber}");
        }
    }
}