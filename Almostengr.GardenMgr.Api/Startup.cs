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
using Almostengr.Common.Twitter.Services;

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

            if (appSettings == null)
            {
                appSettings = new AppSettings();
            }
            
            services.AddSingleton(appSettings);

            services.AddDbContext<GardenDbContext>(options => options.UseSqlite($"Data Source={appSettings.DatabaseFile}"));
            
            services.AddScoped<ITemperatureSensor, MockTemperatureSensor>();
            services.AddScoped<IObservationRepository, ObservationRepository>();
            services.AddScoped<IObservationService, ObservationService>();
            services.AddHostedService<ObservationWorker>();

            services.AddScoped<IPlantWateringRelay, MockPlantWateringRelay>();
            services.AddScoped<IPlantWateringRepository, PlantWateringRepository>();
            services.AddScoped<IPlantWateringService, PlantWateringService>();
            services.AddHostedService<PlantWateringWorker>();
            
            services.AddSingleton<ITwitterService, MockTwitterService>();

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

            UpdateDatabase(app);

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
