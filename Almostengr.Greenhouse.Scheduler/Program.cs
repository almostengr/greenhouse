using Almostengr.Greenhouse.Scheduler.Common;
using Almostengr.Greenhouse.Scheduler.Relays;
using Almostengr.Greenhouse.Scheduler.Relays.Interfaces;
using Almostengr.Greenhouse.Scheduler.Sensors;
using Almostengr.Greenhouse.Scheduler.Sensors.Interface;
using Almostengr.Greenhouse.Scheduler.Workers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Almostengr.Greenhouse.Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSystemd()
                .UseContentRoot(
                    System.IO.Path.GetDirectoryName(
                        System.Reflection.Assembly.GetExecutingAssembly().Location))
                .ConfigureServices((hostContext, services) =>
                {
                    // configuration
                    IConfiguration configuration = hostContext.Configuration;
                    AppSettings appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
                    services.AddSingleton(appSettings);

                    // todo enable when account created
                    // twitter
                    // services.AddSingleton<ITwitterClient, TwitterClient>(tc =>
                    //     new TwitterClient(
                    //         appSettings.Twitter.ConsumerKey,
                    //         appSettings.Twitter.ConsumerSecret,
                    //         appSettings.Twitter.AccessToken,
                    //         appSettings.Twitter.AccessSecret
                    //     ));

                    // database
                    // services.AddDbContext<GreenhouseContext>(options => 
                    //     options.UseInMemory(appSettings.ConnectionString));

                    // workers
                    services.AddHostedService<NwsWeatherWorker>();
                    services.AddHostedService<TemperatureWorker>();
                    // services.AddHostedService<WaterWorker>(); // todo enable when water sensors are available

                    // relays
                    services.AddSingleton<IWaterRelay, WaterRelay>();
                    services.AddSingleton<IFanRelay, FanRelay>();
                    services.AddSingleton<IHeaterRelay, HeaterRelay>();

                    // sensors
                    services.AddSingleton<IThermometerSensor, Ds18b20Sensor>();
                });
    }
}
