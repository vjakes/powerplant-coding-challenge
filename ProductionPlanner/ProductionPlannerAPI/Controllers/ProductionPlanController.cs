using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductionPlannerAPI.Interfaces;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;
        private readonly IProductionRequestLoggerService _productionRequestLoggerService;
        private readonly IPlanningService _planningService;
        private readonly IPlanOutputBuilder _planOutputBuilder;

        public ProductionPlanController(ILogger<ProductionPlanController> logger,
            IProductionRequestLoggerService productionRequestLoggerService,
            IPlanningService planningService,
            IPlanOutputBuilder planOutputBuilder)
        {
            _logger = logger;
            _productionRequestLoggerService = productionRequestLoggerService;
            _planningService = planningService;
            _planOutputBuilder = planOutputBuilder;
        }

        [HttpPost(Name = "/")]
        public async Task<IActionResult> ProductionPlan([FromBody] ProductionRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    _logger.LogWarning("Request was null.");
                    return BadRequest();
                }

                await _productionRequestLoggerService.Save(request, cancellationToken);

                var rawPlan = await _planningService.BuildProductionPlan(request, cancellationToken);
                var outputPlan = _planOutputBuilder.Build(rawPlan, request);

                _logger.LogInformation("Production plan created.");
                return Ok(outputPlan);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while processing production plan: " + e.Message);
                return BadRequest(); 
            }
        }
    }
}