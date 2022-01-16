using Almostengr.GardenMgr.Api.Database;
using Almostengr.GardenMgr.Api.Relays;
using Almostengr.GardenMgr.Api.Services;
using Almostengr.GardenMgr.Api.Sensors;
using Almostengr.GardenMgr.Api.Workers;
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

            // repositories //////////////////////////////////////////////////////////////////////////////////

            services.AddDbContext<GardenDbContext>(options => options.UseSqlite($"Data Source={appSettings.DatabaseFile}"));
            services.AddScoped<IPlantWateringService, PlantWateringService>();
            services.AddScoped<IPlantWateringRelay, PlantWateringRelay>();
            services.AddScoped<IPlantWateringRepository, PlantWateringRepository>();
            
            // workers ///////////////////////////////////////////////////////////////////////////////////////

            services.AddHostedService<ObservationWorker>();
            services.AddHostedService<PlantWateringWorker>();

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

                    services.AddHostedService<TwitterObservationWorker>();
                }
            }

            // relays ////////////////////////////////////////////////////////////////////////////////////////
            
            // services.AddScoped<IPlantWateringRelay, PlantWateringRelay>();
            services.AddScoped<IPlantWateringRelay, MockPlantWateringRelay>();

            // services //////////////////////////////////////////////////////////////////////////////////////

            services.AddScoped<IObservationService, ObservationService>();
            services.AddScoped<IPlantWateringService, PlantWateringService>();

            // sensors ///////////////////////////////////////////////////////////////////////////////////////

            // services.AddSingleton<ISensor, Sensor>();
            services.AddScoped<ITemperatureSensor, MockTemperatureSensor>();

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
            else {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // perform database updates if any are available
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<GardenDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
