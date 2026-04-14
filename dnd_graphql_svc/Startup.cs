using AutoMapper;
using dnd_dal.dao;
using dnd_service_logic.BL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace dnd_graphql_svc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                var licenseKey = Configuration["AutoMapper:LicenseKey"];
                if (!string.IsNullOrWhiteSpace(licenseKey))
                {
                    cfg.LicenseKey = licenseKey;
                }
            }, typeof(Startup));

            var connectionString = Configuration.GetConnectionString("DndDatabase")
                ?? $"Data Source={System.IO.Path.Combine(System.AppContext.BaseDirectory, "Data", "dnd.sqlite")}";

            services.AddDbContext<dndContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<ISpellLogic, SpellLogic>();
            services.AddScoped<IFeatLogic, FeatLogic>();
            services.AddScoped<ILookupLogic, LookupLogic>();
            services.AddScoped<IClassLogic, ClassLogic>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
