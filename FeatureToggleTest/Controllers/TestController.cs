using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace FeatureToggleTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IFeatureManager _featureManager;

        public TestController(
            ILogger<TestController> logger,
            IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        [HttpGet]
        [FeatureGate(FeatureFlags.Beta)]
        public IActionResult Get()
        {
            return Ok("A feature está funcionando!");
        }
    }
}