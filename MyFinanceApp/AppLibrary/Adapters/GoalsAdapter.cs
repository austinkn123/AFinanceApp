using AppLibrary.Models;
using AppLibrary.UseCases;
using ConnectionStrings;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Adapters
{
    [DatabaseService(ConnectionString.Finance)]
    public abstract class GoalsAdapter
    {
        public abstract IDbConnection GetConnection();

        public async Task<IEnumerable<Goal>> GetAll(int userId)
        {
            return await GetConnection().QuerySqlAsync<Goal>(getAllGoals, new { userId });
        }

        #region queries
        private const string getAllGoals = @"
            SELECT goal_id
                  ,user_id
                  ,name
                  ,description
                  ,begin_date
                  ,end_date
                  ,amount 
                  ,goal_amount
            FROM public.goals
            WHERE user_id = @userId
        ";

        private const string getGoalById = @"
            SELECT goal_id
                  ,user_id
                  ,transaction_id
                  ,name
                  ,description
                  ,begin_date
                  ,end_date
                  ,amount 
                  ,goal_amount
            FROM public.goals
            WHERE goal_id = @id
        ";

        private const string addGoal = @"
            INSERT INTO public.goals (
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

        private const string deleteGoal = @"
            DELETE FROM public.users WHERE user_id = @id
        ";

        private const string updateGoal = @"
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
