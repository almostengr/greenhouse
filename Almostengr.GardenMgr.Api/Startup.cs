using Almostengr.GardenMgr.Common;
using Almostengr.GardenMgr.Common.Database;
using Almostengr.GardenMgr.Irrigation.Database;
using Almostengr.GardenMgr.Irrigation.Relays;
using Almostengr.GardenMgr.Irrigation.Services;
using Almostengr.GardenMgr.WeatherStation.Sensors;
using Almostengr.GardenMgr.WeatherStation.Sensors.Interface;
using Almostengr.GardenMgr.WeatherStation.Services;
using Almostengr.GardenMgr.WeatherStation.Services.Interface;
using Almostengr.GardenMgr.WeatherStation.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tweetinvi;

namespace Almostengr.GardenMgr.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });

            AppSettings appSettings = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            services.AddSingleton(appSettings);

            services.AddScoped<IPlantWateringService, PlantWateringService>();
            services.AddScoped<IIrrigationRelay, IrrigationRelay>();
            services.AddScoped<IPlantWateringRepository, PlantWateringRepository>();

            // repositories //////////////////////////////////////////////////////////////////////////////////

            services.AddDbContext<GardenDbContext>(options => options.UseSqlite($"Data Source={appSettings.DatabaseFile}"));

            
            // workers ///////////////////////////////////////////////////////////////////////////////////////

            services.AddHostedService<ObservationWorker>();

            if (appSettings.Twitter != null)
            {
                if (string.IsNullOrEmpty(appSettings.Twitter.ConsumerKey) == false &&
                string.IsNullOrEmpty(appSettings.Twitter.ConsumerSecret) == false &&
                string.IsNullOrEmpty(appSettings.Twitter.AccessToken) == false &&
                string.IsNullOrEmpty(appSettings.Twitter.AccessSecret) == false)
                {
                    services.AddSingleton<ITwitterClient, TwitterClient>(tc =>
                        new TwitterClient(
                            appSettings.Twitter.ConsumerKey,
                            appSettings.Twitter.ConsumerSecret,
                            appSettings.Twitter.AccessToken,
                            appSettings.Twitter.AccessSecret
                        ));

                    services.AddHostedService<TwitterReportWorker>();
                }
            }

            // services //////////////////////////////////////////////////////////////////////////////////////

            services.AddScoped<IObservationService, ObservationService>();

            // sensors ///////////////////////////////////////////////////////////////////////////////////////

            // services.AddSingleton<ISensor, Sensor>();
            services.AddScoped<ISensor, MockSensor>();

            services.AddDbContext<GardenDbContext>(options => options.UseSqlite($"Data Source={appSettings.DatabaseFile}"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Almostengr.GardenMgr.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Almostengr.GardenMgr.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
