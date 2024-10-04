using AppLibrary.Models;
using ConnectionStrings;
using Insight.Database;
using System.Data;

namespace AppLibrary.Adapters
{
    [DatabaseService(ConnectionString.Finance)]
    public abstract class UserAdapter
    {
        public abstract IDbConnection GetConnection();
        public async Task<IEnumerable<User>> GetAll()
        {
            return await GetConnection().QuerySqlAsync<User>(getAllUsers);
        }

        public async Task Add(User user)
        {
            var expando = user.Expand(new
            {
                user.Cognito_User_Id,
                user.User_Name,
                user.Phone_Number,
                user.Email,
                user.First_Name,
                user.Last_Name

            });
            await GetConnection().ExecuteSqlAsync(signUpUserSQL, expando);
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
            FROM public.users
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

        //private const string addUser = @"
        //    INSERT INTO public.users (
        //        user_name
        //        ,password
        //        ,phone_number
        //        ,email 
        //        ,first_name
        //        ,last_name
        //    ) VALUES (
        //        @User_Name
        //        ,@Password
        //        ,@Phone_Number
        //        ,@Email
        //        ,@First_Name
        //        ,@Last_Name
        //    );
        //";

        private const string signUpUserSQL = @"
            INSERT INTO public.users (
                cognito_user_id
                ,user_name
                ,password
                ,phone_number
                ,email 
                ,first_name
                ,last_name
            ) VALUES (
                @Cognito_User_Id
                ,@User_Name
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
