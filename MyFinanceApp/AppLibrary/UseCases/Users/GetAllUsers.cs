using AppLibrary.Adapters;
using AppLibrary.Models;

namespace AppLibrary.UseCases.Users
{
    [TransientService]
    public class GetAllUsers(UserAdapter _userAdapter)
    {
        public async Task<IEnumerable<User>> Execute() => await _userAdapter.GetAll();
    }
}
