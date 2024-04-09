using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Data.UserDAO
{
    public interface IUserData
    {
        public DbSet<User> GetUsers();

        public void CreateUser(User user);

        public void CreateUsers(IEnumerable<User> users);

        public void UpdateUser(User user);

        public void DeleteUser(User user);
    }
}
