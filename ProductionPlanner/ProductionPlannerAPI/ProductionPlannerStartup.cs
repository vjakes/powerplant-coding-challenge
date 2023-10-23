using System;
using Microsoft.Extensions.DependencyInjection;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;
using ProductionPlannerAPI.Services;
using ProductionPlannerAPI.Services.CapacityBuilders;

namespace ProductionPlannerAPI
{
    public static class ProductionPlannerStartup
    {
        public static void Configure(this IServiceCollection services)
        {
            services.AddTransient<Func<string, ICapacityBuilder>>((sp) => (key) =>
                {
                    // TODO: once capacity builders that factor in CO2 emissions are implemented, this will be revisited.
                    switch (key)
                    {
                        case PlantTypes.Windturbine: return new WindturbineCapacityBuilder();
                        case PlantTypes.Gasfired: return new GasfiredCapacityBuilder();
                        case PlantTypes.Turbojet: return new KeroseneCapacityBuilder();
                    }

                    throw new NotImplementedException();
                })
                .AddTransient<IProductionRequestLoggerService, ProductionRequestLoggerService>()
                .AddTransient<IPlanningService, PlanningService>()
                .AddTransient<IPlanOutputBuilder, PlanOutputBuilder>()
                .AddTransient<IPlantOrderingRepository, MeritOrderPlantRepository>();
        }
    }
}
