using AppLibrary.Models;

namespace AppLibrary.IRepositories
{
    public interface ITestRepository
    {
        public Task<IEnumerable<Test>> GetAll();
    }
}
