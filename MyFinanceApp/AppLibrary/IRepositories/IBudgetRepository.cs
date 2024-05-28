using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.IRepositories
{
    public interface IBudgetRepository
    {
        public Task<IEnumerable<Budget>> GetAll();
        public Task<Budget> GetById(int id);
        public Task AddBudget(Budget model);
        public Task DeleteBudget(int id);
        public Task UpdateBudget(Budget model);
    }
}
