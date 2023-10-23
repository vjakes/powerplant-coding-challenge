using System;
using System.Collections.Generic;
using System.Linq;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Services
{
    /// <summary>
    /// Possibly joins multiple powerplant requests into one and then provides powerplant
    /// capacities in the merit order 
    /// </summary>
    public class MeritOrderPlantRepository : IPlantOrderingRepository
    {
        private readonly Func<string, ICapacityBuilder> _capacityBuilders;
        private readonly List<PowerplantRequest> _plants;

        public MeritOrderPlantRepository(Func<string, ICapacityBuilder> capacityBuilders)
        {
            _capacityBuilders = capacityBuilders;
            _plants = new List<PowerplantRequest>();
        }

        public void AddPowerplants(IEnumerable<PowerplantRequest> plantsAvailable)
        {
            _plants.AddRange(plantsAvailable);
        }

        public IEnumerable<PowerplantCapacity> GetPowerplantCapacities(FuelRequest costData)
        {
            var groupedPlants = _plants.GroupBy(gb => gb.Type);

            var ret = new List<PowerplantCapacity>();

            foreach (var plantGroup in groupedPlants)
            {
                ret.AddRange(_capacityBuilders(plantGroup.Key)
                    .GetCapacities(plantGroup, costData));
            }
            
            return ret.OrderBy(b => b.UnitPrice);
        }
    }
}
