using Ipr.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ipr.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly TransientService _service;

        private readonly SingletonService _singleton;

        private readonly ScopedService _scopedService;

        //private readonly TransientService _transientService;

        public WeatherForecastController(
            TransientService service, SingletonService singleton, ScopedService scopedService)
        {

            _service = service;
            _singleton = singleton;
            _scopedService = scopedService;
        }

        [HttpGet]
        [Route("transient")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(_service.Increment());
        }

        [HttpGet]
        [Route("singleton")]
        public async Task<IActionResult> GetAsync2()
        {
            return Ok(_singleton.Increment());
        }

        [HttpGet]
        [Route("scoped")]
        public async Task<IActionResult> GetAsync3()
        {
            return Ok(_scopedService.Increment());
        }
    }
}
