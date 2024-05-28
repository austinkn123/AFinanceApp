using AppLibrary.DiConfigs;
using AppLibrary.IRepositories;
using AppLibrary.Models;
using Dapper;

namespace AppLibrary.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ConfigureServices _context;
        public BudgetRepository(ConfigureServices context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var budgets = await connection.QueryAsync<Budget>(getAllBudgets);
            return budgets;
        }

        public async Task<Budget> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var budget = await connection.QueryFirstOrDefaultAsync<Budget>(getBudgetById, new { id });
            return budget;
        }

        public async Task AddBudget(Budget model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(addBudget, model);
        }

        public async Task DeleteBudget(int id)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(deleteBudget, new { id });
        }

        public async Task UpdateBudget(Budget model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(updateBudget, model);
        }

        #region queries
        private const string getAllBudgets = @"
            SELECT budget_id
                  ,name
                  ,begin_date
                  ,end_date
                  ,amount 
                  ,user_id
                  ,transaction_id
            FROM public.Budgets
        ";

        private const string getBudgetById = @"
            SELECT budget_id
                  ,name
                  ,begin_date
                  ,end_date
                  ,amount 
                  ,user_id
                  ,transaction_id
            FROM public.Budgets
            WHERE budget_id = @id
        ";

        private const string addBudget = @"
            INSERT INTO public.Budgets (
                budget_id
                  ,name
                  ,begin_date
                  ,end_date
                  ,amount 
                  ,user_id
                  ,transaction_id
            ) VALUES (
                @Budget_id
                ,@Name
                ,@Begin_date
                ,@End_date
                ,@Amount 
                ,@User_id
                ,@Transaction_id
            );
        ";

        private const string deleteBudget = @"
            DELETE FROM public.Budgets WHERE budget_id = @id
        ";

        private const string updateBudget = @"
            UPDATE public.Budgets 
            SET
                budget_id = @Budget_id
                ,name = @Name
                ,begin_date = @Begin_date
                ,end_date = @End_date
                ,amount = @Amount
                ,user_id = @User_id
                ,transaction_id = @Transaction_id
            WHERE budget_id = @Budget_id
        ";

        #endregion
    }
}
