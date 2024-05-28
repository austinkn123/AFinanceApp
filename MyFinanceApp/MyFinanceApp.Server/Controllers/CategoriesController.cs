using AppLibrary.IRepositories;
using AppLibrary.Models;
using AppLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyFinanceApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("get-category/{id}")]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var category = await _categoryRepository.GetById(id);
            return Ok(category);

        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory([FromBody] Category model)
        {
            await _categoryRepository.AddCategory(model);
            return Ok();
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryRepository.DeleteCategory(id);
            return Ok();
        }

        [HttpPatch("update-category")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category model)
        {
            await _categoryRepository.UpdateCategory(model);
            return Ok();
        }
    }
}
