using System.Device.Gpio;

namespace Almostengr.Greenhouse.Microcontroller;
static class Program
{
    // climate
    private const int HEATER_RELAY_PIN = 4;
    private const int HEATER_SETPOINT_F = 60;
    private const int COOLING_SETPOINT_F = 85;
    private const int COOLING_RELAY_PIN = 5;
    private const int FAN_RELAY_PIN = 45;

    // lighting
    private const int LIGHTING_RELAY_PIN = 7;
    
    // watering
    private const int WATER_PUMP_PIN = 15;
    private const int WATER_TIME = 30000; // 30 seconds

    public const int SLEEP_DELAY = 1000;
    private static GpioController gpioController;


    static async void Main(string[] args)
    {
        // initialize

        gpioController = new GpioController();
        gpioController.OpenPin(COOLING_RELAY_PIN, PinMode.Output, PinValue.Low);
        gpioController.OpenPin(FAN_RELAY_PIN, PinMode.Output, PinValue.Low);
        gpioController.OpenPin(HEATER_RELAY_PIN, PinMode.Output, PinValue.Low);
        gpioController.OpenPin(LIGHTING_RELAY_PIN, PinMode.Output, PinValue.Low);
        gpioController.OpenPin(WATER_PUMP_PIN, PinMode.Output, PinValue.Low);


        while (true)
        {
            // GetTemperatureData

            // SaveTemperatureData

            // CycleCooling

            // CycleHeating

            // cycle fan


            // check moisture level

            // if level is low, turn on pump for 30 seconds

            // turn off pump


            // check lighting level and time of day

            // turn on or off light per conditions 


            // await Task.Delay(TimeSpan.FromMinutes(1));
            Thread.Sleep(SLEEP_DELAY);
        }

        Thread.Sleep(Timeout.Infinite);

    } // end main
}


// https://docs.nanoframework.net/api/index.html
