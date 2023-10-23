using System.Collections.Generic;
using System.Linq;
using ProductionPlannerAPI.Models;
using ProductionPlannerAPI.Services;

namespace ProductionPlannerAPI.Interfaces
{
    public interface ICapacityBuilder
    {
        IEnumerable<PowerplantCapacity> GetCapacities(IGrouping<string, PowerplantRequest> powerplantRequests, FuelRequest costData);
    }
}
