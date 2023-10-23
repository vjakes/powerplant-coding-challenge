using System;
using System.Collections.Generic;
using System.Linq;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Services.CapacityBuilders
{
    public class WindturbineCapacityBuilder : ICapacityBuilder
    {
        public IEnumerable<PowerplantCapacity> GetCapacities(IGrouping<string, PowerplantRequest> powerplantRequests, FuelRequest costData)
        {
            return powerplantRequests.OrderBy(ob => ob.PowerMax * costData.WindEfficiency)
                .Select(s => new PowerplantCapacity()
                {
                    PMax = s.PowerMax * s.Efficiency * costData.WindEfficiency / 100,
                    PMin = s.PowerMin * s.Efficiency * costData.WindEfficiency / 100,
                    Name = s.Name,
                    UnitPrice = 0f
                });
        }
    }
}
