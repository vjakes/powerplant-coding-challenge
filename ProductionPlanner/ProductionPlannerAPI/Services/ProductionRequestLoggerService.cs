using System.Threading;
using System.Threading.Tasks;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Services
{
    public class ProductionRequestLoggerService : IProductionRequestLoggerService
    {
        public Task Save(ProductionRequest request, CancellationToken cancellationToken)
        {
            // TODO: store the request data into database tables to provide basis for auditing, tracing etc. 
            // Decide: EF and relational database with three tables seems OK for this?
            // TODO: Map input request to database model - to be implemented. Use Automapper/xpres mapper for mappings?

            return Task.CompletedTask;
        }
    }
}
