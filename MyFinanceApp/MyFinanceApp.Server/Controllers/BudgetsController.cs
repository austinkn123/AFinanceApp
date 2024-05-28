using AppLibrary.IRepositories;
using AppLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyFinanceApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : Controller
    {
        private readonly ILogger<BudgetsController> _logger;
        private readonly IBudgetRepository _budgetRepository;
        public BudgetsController(ILogger<BudgetsController> logger, IBudgetRepository budgetRepository) {
            _logger = logger;
            _budgetRepository = budgetRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var budgets = await _budgetRepository.GetAll();
            return Ok(budgets);
        }

        [HttpGet("get-budget/{id}")]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var budget = await _budgetRepository.GetById(id);
            return Ok(budget);

        }

        [HttpPost("add-budget")]
        public async Task<IActionResult> AddBudget([FromBody] Budget model)
        {
            await _budgetRepository.AddBudget(model);
            return Ok();
        }

        [HttpDelete("delete-budget/{id}")]
        public async Task<IActionResult> DeletBudget([FromRoute] int id)
        {
            await _budgetRepository.DeleteBudget(id);
            return Ok();
        }

        [HttpPatch("update-budget")]
        public async Task<IActionResult> UpdateBudget([FromBody] Budget model)
        {
            await _budgetRepository.UpdateBudget(model);
            return Ok();
        }

    }
}
