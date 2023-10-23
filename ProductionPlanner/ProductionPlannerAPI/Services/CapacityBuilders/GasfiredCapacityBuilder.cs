using System.Collections.Generic;
using System.Linq;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Services.CapacityBuilders
{
    public class GasfiredCapacityBuilder : ICapacityBuilder
    {
        public IEnumerable<PowerplantCapacity> GetCapacities(IGrouping<string, PowerplantRequest> powerplantRequests, FuelRequest costData)
        {
            return powerplantRequests.OrderBy(ob => ob.PowerMax)
                .Select(s => new PowerplantCapacity()
                {
                    PMax = s.PowerMax,
                    PMin = s.PowerMin,
                    Name = s.Name,
                    UnitPrice = costData.GasCostMWh / s.Efficiency
                });
        }
    }
}
