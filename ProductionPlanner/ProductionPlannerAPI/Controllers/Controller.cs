using Microsoft.AspNetCore.Mvc;
using ProductionPlannerAPI.Models;

namespace ProductionPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<Controller> _logger;

        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "/productionplan")]
        public async Task<IActionResult> ProductionPlan([FromBody] ProductionRequest request, CancellationToken cancellationToken)
        {
            
            return Ok();
        }
    }
}