using AppLibrary.IRepositories;
using AppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFianceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestRepository _testRepository;
        public TestController(ILogger<TestController> logger, ITestRepository testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tests = await _testRepository.GetAll();
                return Ok(tests);
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}

