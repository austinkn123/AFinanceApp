using AppLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Adapters
{
    [DatabaseService(ConnectionStrings.Finance)]
    public abstract class FinanceAdapter
    {
        public async Task<IEnumerable<User>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var users = await connection.QueryAsync<User>(getAllUsers);
            return users;
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
