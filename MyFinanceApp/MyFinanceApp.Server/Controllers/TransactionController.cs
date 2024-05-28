using AppLibrary.IRepositories;
using AppLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyFinanceApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ILogger<TransactionController> logger, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionRepository.GetAll();
            return Ok(transactions);
        }

        [HttpGet("get-transaction/{id}")]

        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var transaction = await _transactionRepository.GetById(id);
            return Ok(transaction);

        }

        [HttpPost("add-transaction")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction model)
        {
            await _transactionRepository.AddTransaction(model);
            return Ok();
        }

        [HttpDelete("delete-transaction/{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            await _transactionRepository.DeleteTransaction(id);
            return Ok();
        }

        [HttpPatch("update-transaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] Transaction model)
        {
            await _transactionRepository.UpdateTransaction(model);
            return Ok();
        }
    }
}
