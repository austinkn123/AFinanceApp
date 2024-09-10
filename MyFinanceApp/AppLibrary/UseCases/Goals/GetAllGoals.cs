using AppLibrary.Adapters;
using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.UseCases.Goals
{
    [TransientService]
    public class GetAllGoals(GoalsAdapter _goalsAdapter)
    {
        public async Task<IEnumerable<Goal>> Execute(int userId) => await _goalsAdapter.GetAll(userId);
    }
}
