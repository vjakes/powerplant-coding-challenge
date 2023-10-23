using System.Threading;
using System.Threading.Tasks;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Interfaces
{
    public interface IProductionRequestLoggerService
    {
        Task Save(ProductionRequest request, CancellationToken cancellationToken);
    }
}
