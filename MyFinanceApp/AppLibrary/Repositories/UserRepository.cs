using AppLibrary.DiConfigs;
using AppLibrary.IRepositories;
using AppLibrary.Models.User;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConfigureServices _context;
        public UserRepository(ConfigureServices context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var users = await connection.QueryAsync<User>(getAllUsers);
            return users;
        }


        public async Task<User> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var user = await connection.QueryFirstOrDefaultAsync<User>(getUserById, new { id });
            return user;
        }

        public async Task AddUser(User model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(addUser, model);
        }

        public async Task DeleteUser(int id)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(deleteUser, new { id });
        }

        public async Task UpdateUser(User model)
        {
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(updateUser, model);
        }

        #region queries
        private const string getAllUsers = @"
            SELECT user_id
                  ,user_name
                  ,password
                  ,phone_number
                  ,email 
                  ,first_name
                  ,last_name
            FROM public.user
        ";

        private const string getUserById = @"
            SELECT user_id
                  ,user_name
                  ,password
                  ,phone_number
                  ,email 
                  ,first_name
                  ,last_name
            FROM public.users
            WHERE user_id = @id
        ";

        private const string addUser = @"
            INSERT INTO public.users (
                user_name
                ,password
                ,phone_number
                ,email 
                ,first_name
                ,last_name
            ) VALUES (
                @User_Name
                ,@Password
                ,@Phone_Number
                ,@Email
                ,@First_Name
                ,@Last_Name
            );
        ";

        private const string deleteUser = @"
            DELETE FROM public.users WHERE user_id = @id
        ";

        private const string updateUser = @"
            UPDATE public.users 
            SET
                user_name = @User_Name
                ,password = @Password
                ,phone_number = @Phone_Number
                ,email = @Email
                ,first_name = @First_Name
                ,last_name = @Last_Name
            WHERE user_id = @User_Id
        ";

        #endregion

    }
}
