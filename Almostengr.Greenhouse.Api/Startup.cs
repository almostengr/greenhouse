using Almostengr.Greenhouse.Api.Database;
using Almostengr.Greenhouse.Api.Relays;
using Almostengr.Greenhouse.Api.Relays.Interfaces;
using Almostengr.Greenhouse.Api.Sensors;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;
using Almostengr.Greenhouse.Api.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Almostengr.Greenhouse.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Almostengr.Greenhouse.Api", Version = "v1" });
            });

            // database
            services.AddDbContext<GreenhouseContext>(options => 
                options.UseInMemoryDatabase("Greenhouse"));
            // services.AddDbContext<GreenhouseContext>(options => 
            //     options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            // relays
            services.AddSingleton<IIrrigationRelay, IrrigationRelay>();
            services.AddSingleton<IFanRelay, FanRelay>();
            services.AddSingleton<IHeaterRelay, HeaterRelay>();

            // sensors
            // services.AddSingleton<ITemperatureSensor, Ds18b20Sensor>();
            services.AddSingleton<ITemperatureSensor, MockTemperatureSensor>();
            services.AddSingleton<IMoistureSensor, MockMoistureSensor>();

            // workers
            services.AddHostedService<TemperatureWorker>();
            services.AddHostedService<IrrigationWorker>();
            services.AddHostedService<NwsWeatherWorker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Almostengr.Greenhouse.Api v1"));
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
