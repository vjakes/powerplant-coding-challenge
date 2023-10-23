using System.Collections.Generic;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Interfaces
{
    public interface IPlanOutputBuilder
    {
        IList<ProductionPlanItem> Build(IList<CapacityItemPlaning> result, ProductionRequest request);
    }
}
