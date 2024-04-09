using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Data.UserDAO
{
    public class UserData(AppDbContext dbContext) : IUserData
    {
        private readonly AppDbContext _dbContext = dbContext;

        public DbSet<User> GetUsers() => _dbContext.Users;


        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChangesAsync();
        }

    }
}
