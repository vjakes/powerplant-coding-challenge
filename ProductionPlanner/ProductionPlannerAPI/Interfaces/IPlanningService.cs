using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Interfaces
{
    public interface IPlanningService 
    {
        Task<IList<CapacityItemPlaning>> BuildProductionPlan(ProductionRequest request, CancellationToken cancellationToken);
    }
}
