using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Data.UserDAO
{
    public interface IUserData
    {
        public DbSet<User> GetUsers();

        public DbSet<User> CreateUser(User user);

    }
}
