using AppLibrary.DiConfigs;
using AppLibrary.IRepositories;
using AppLibrary.Models;
using Dapper;
using System.Data;

namespace AppLibrary.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ConfigureServices _context;

        public TestRepository(ConfigureServices context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Test>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var tests = await connection.QueryAsync<Test>(getAllTests);
                return tests;
            }
            //return await _connection.SingleAsync<Test>(getAllTests);
        }


        #region sql
        private const string getAllTests = @"SELECT User_Id, User_Name, Password, Phone_Number, Email FROM public.Users";

        #endregion
    }
}
