using AppLibrary.Adapters;
using AppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.UseCases.Users
{
    [TransientService]
    public class SignUpUser(UserAdapter userAdapter)
    {
        public async Task Execute(User user)
        {
            user.Password = HashPassword(user.Password);

            await userAdapter.Add(user);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
