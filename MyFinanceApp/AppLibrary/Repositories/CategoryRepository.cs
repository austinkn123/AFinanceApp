using AppLibrary.DiConfigs;
using AppLibrary.IRepositories;
using AppLibrary.Models;
using Dapper;

namespace AppLibrary.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ConfigureServices _context;
        public CategoryRepository(ConfigureServices context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var categories = await connection.QueryAsync<Category>(getAllCategories);
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var category = await connection.QueryFirstOrDefaultAsync<Category>(getCategoryById, new { id });
            return category;
        }

        public async Task AddCategory(Category model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(addCategory, model);
        }

        public async Task DeleteCategory(int id)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(deleteCategory, new { id });
        }

        public async Task UpdateCategory(Category model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(updateCategory, model);
        }

        #region queries
        private const string getAllCategories = @"
            SELECT category_id
                  ,type
                  ,budget_id
                  ,transaction_id
            FROM public.Categories
        ";

        private const string getCategoryById = @"
            SELECT category_id
                  ,type
                  ,budget_id
                  ,transaction_id
            FROM public.Categories
            WHERE category_id = @id
        ";

        private const string addCategory = @"
            INSERT INTO public.Categories (
                category_id
                ,type
                ,budget_id
                ,transaction_id
            ) VALUES (
                @Category_id
                ,@Type
                ,@Budget_id
                ,@Transaction_id
            );
        ";

        private const string deleteCategory = @"
            DELETE FROM public.Categories WHERE category_id = @id
        ";

        private const string updateCategory = @"
            UPDATE public.Categories 
            SET
                category_id = @Category_id
                ,type = @Type
                ,budget_id = @Budget_id
                ,transaction_id = @Transaction_id
            WHERE category_id = @Category_id
        ";

        #endregion
    }
}
