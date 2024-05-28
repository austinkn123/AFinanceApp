using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.IRepositories
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> GetAll();
        public Task<Transaction> GetById(int id);
        public Task AddTransaction(Transaction model);
        public Task DeleteTransaction(int id);
        public Task UpdateTransaction(Transaction model);
    }
}
