using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly IPlantOrderingRepository _plantRepository;
        private readonly ILogger<PlanningService> _logger;

        public PlanningService(IPlantOrderingRepository plantRepository, ILogger<PlanningService> logger)
        {
            _plantRepository = plantRepository;
            _logger = logger;
        }

        public Task<IList<CapacityItemPlaning>> BuildProductionPlan(ProductionRequest request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Building plant list");
            _plantRepository.AddPowerplants(request.Powerplants);

            float uncoveredCapacity = request.Load;
            var capacityItemPlanings = new List<CapacityItemPlaning>();

            while (uncoveredCapacity != 0) // As long as we have some load unsettled....
            {
                if (uncoveredCapacity > 0) // We need to add more power capacities.
                {
                    _logger.LogDebug("Adding to the capacity to be produced.");
                    foreach (var capacity in _plantRepository.GetPowerplantCapacities(request.Fuels)
                                 .Where(w => capacityItemPlanings.All(a => a.Capacity.Name != w.Name))) 
                    {
                        uncoveredCapacity -= capacity.PMax;
                        capacityItemPlanings.Add(new CapacityItemPlaning()
                        {
                            Capacity = capacity, 
                            Plan = new ProductionPlanItem() {PlantName = capacity.Name, Power = capacity.PMax}
                        });
                        if (uncoveredCapacity <= 0) break;
                    }
                }
                else // we need to cut some capacities.
                {
                    _logger.LogDebug("Cutting down capacity to be produced.");
                    capacityItemPlanings.Reverse(); // Start with the most expensive one/last one added.
                    foreach (var exceeding in capacityItemPlanings)
                    {
                        var absUncovered = Math.Abs(uncoveredCapacity);
                        var availableRange = exceeding.Capacity.PMax - exceeding.Capacity.PMin;
                        if (absUncovered < availableRange)
                        {
                            exceeding.Plan.Power = exceeding.Capacity.PMax - absUncovered;
                            uncoveredCapacity += absUncovered;
                            break;
                        }

                        exceeding.Plan.Power = exceeding.Capacity.PMin;
                        uncoveredCapacity += availableRange;
                    }
                }
            }

            _logger.LogDebug("Capacity plan ready.");
            return Task.FromResult((IList<CapacityItemPlaning>)capacityItemPlanings);
        }
    }
}
