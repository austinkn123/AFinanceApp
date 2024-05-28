using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.IRepositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task<Category> GetById(int id);
        public Task AddCategory(Category model);
        public Task DeleteCategory(int id);
        public Task UpdateCategory(Category model);
    }
}
