using System.Collections.Generic;
using System.Linq;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Services
{
    /// <summary>
    /// Makes sure that non-utilized plants receive a 0 request.
    /// </summary>
    public class PlanOutputBuilder : IPlanOutputBuilder
    {
        public IList<ProductionPlanItem> Build(IList<CapacityItemPlaning> result, ProductionRequest request)
        {
            var plan = result.Select(s => s.Plan).ToList();
            plan.AddRange(request.Powerplants.Where(w => plan.All(a => a.PlantName != w.Name)).Select(s => new ProductionPlanItem()
            {
                PlantName = s.Name,
                Power = 0f
            }));
            return plan;
        }
    }
}
