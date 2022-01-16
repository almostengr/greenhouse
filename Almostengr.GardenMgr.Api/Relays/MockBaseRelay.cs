using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Relays
{
    public class MockBaseRelay : IBaseRelay
    {
        private readonly ILogger<MockBaseRelay> _logger;

        public MockBaseRelay(ILogger<MockBaseRelay> logger)
        {
            _logger = logger;
        }

        public void ClosePin(GpioController gpio, int gpioNumber)
        {
            _logger.LogInformation($"Closing GPIO {gpioNumber}");
        }

        public void OpenPin(int pin)
        {
            _logger.LogInformation($"Opening GPIO {pin}");
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int gpioNumber)
        {
            _logger.LogInformation($"Opening GPIO {gpioNumber}");
        }

        public void TurnOff(int gpioNumber)
        {
            _logger.LogInformation($"Turning off GPIO {gpioNumber}");
        }

        public void TurnOn(int gpioNumber)
        {
            _logger.LogInformation($"Turning on GPIO {gpioNumber}");
        }
    }
}