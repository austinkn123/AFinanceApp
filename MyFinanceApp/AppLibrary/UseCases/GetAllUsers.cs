using AppLibrary.Adapters;
using AppLibrary.Models;

namespace AppLibrary.UseCases
{
    [TransientService]
    public class GetAllUsers(FinanceAdapter _financeAdapter)
    {
        public async Task<IEnumerable<User>> Execute() => await _financeAdapter.GetAll();
    }
}
