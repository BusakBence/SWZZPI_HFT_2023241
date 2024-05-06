using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SWZZPI_HFT_2023241.Logic;
using SWZZPI_HFT_2023241.Models;
using SWZZPI_HFT_2023241.Repository;

namespace SWZZPI_HFT_2023241.Endpoint
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<LolDBContext>();
            services.AddTransient<IRepository<Champions>, ChampionsRepository>();
            services.AddTransient<IRepository<Regions>, RegionsRepository>();
            services.AddTransient<IRepository<Abilities>, AbilitiesRepository>();
            services.AddTransient<IChampionsLogic, ChampionsLogic>();
            services.AddTransient<IRegionsLogic, RegionsLogic>();
            services.AddTransient<IAbilitiesLogic, AbilitiesLogic>();
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "SWZZPI_HFT_2023241.Endpoint", Version = "v1" });
            });
            services.AddSignalR();
        }       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "SWZZPI_HFT_2023241.Endpoint v1"));
            }
            app.UseExceptionHandler(s => s.Run(async c => 
            {
                var exception = c.Features
                                .Get<IExceptionHandlerPathFeature>()
                                .Error;
                var response = new { Msg = exception.Message };
                await c.Response.WriteAsJsonAsync(response);
            }));          
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
