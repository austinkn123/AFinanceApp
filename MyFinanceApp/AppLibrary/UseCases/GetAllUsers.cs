using AppLibrary.Adapters;
using AppLibrary.Models;

namespace AppLibrary.UseCases
{
    [TransientService]
    public class GetAllUsers(FinanceAdapter _financeAdapter)
    {
        public Task<IEnumerable<User>> Execute() => _financeAdapter.GetAll();
    }
}
