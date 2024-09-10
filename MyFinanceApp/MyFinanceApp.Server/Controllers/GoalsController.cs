using AppLibrary.UseCases.Goals;
using AppLibrary.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace MyFinanceApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : Controller
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllGoals([FromServices] GetAllGoals getAllGoals, [FromRoute] int userId)
            => Ok(await getAllGoals.Execute(userId));
    }
}
