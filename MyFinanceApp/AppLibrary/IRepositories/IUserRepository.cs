using AppLibrary.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.IRepositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> GetById(int id);
        public Task AddUser(User model);
        public Task DeleteUser(int id);
        public Task UpdateUser(User model);
    }
}
