using System.Collections;
using System.Collections.Generic;
using ProductionPlannerAPI.Models;
using ProductionPlannerAPI.Services;

namespace ProductionPlannerAPI.Interfaces
{
    /// <summary>
    /// Implementations of this interface should order the available plants according to their specific
    /// </summary>
    public interface IPlantOrderingRepository
    {
        public void AddPowerplants(IEnumerable<PowerplantRequest> plantsAvailable);

        public IEnumerable<PowerplantCapacity> GetPowerplantCapacities(FuelRequest costData);
    }
}
