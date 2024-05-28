using AppLibrary.DiConfigs;
using AppLibrary.IRepositories;
using AppLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ConfigureServices _context;
        public TransactionRepository(ConfigureServices context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var transactions = await connection.QueryAsync<Transaction>(getAllTransaction);
            return transactions;
        }

        public async Task<Transaction> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var transaction = await connection.QueryFirstOrDefaultAsync<Transaction>(getTransactionById, new { id });
            return transaction;
        }
        public async Task AddTransaction(Transaction model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(addTransaction, model);
        }

        public async Task DeleteTransaction(int id)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(deleteTransaction, new { id });
        }

        public async Task UpdateTransaction(Transaction model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(updateTransaction, model);
        }

        #region queries
        private const string getAllTransaction = @"
            SELECT transaction_id
                  ,transaction_date
                  ,amount
                  ,description
            FROM public.Transactions
        ";

        private const string getTransactionById = @"
            SELECT transaction_id
                  ,transaction_date
                  ,amount
                  ,description
            FROM public.Transactions
            WHERE transaction_id = @id
        ";

        private const string addTransaction = @"
            INSERT INTO public.Transactions (
                  transaction_id
                  ,transaction_date
                  ,amount
                  ,description
            ) VALUES (
                @Transaction_id
                ,@Transaction_date
                ,@Amount 
                ,@Description
            );
        ";

        private const string deleteTransaction = @"
            DELETE FROM public.Transactions WHERE transaction_id = @id
        ";

        private const string updateTransaction = @"
            UPDATE public.Transactions 
            SET
                transaction_id = @Transaction_id
                ,transaction_date = @Transaction_date
                ,amount = @Amount
                ,description = @Description
            WHERE budget_id = @Budget_id
        ";

        #endregion
    }
}
