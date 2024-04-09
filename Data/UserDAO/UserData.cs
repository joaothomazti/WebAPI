using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Data.UserDAO
{
    public class UserData(AppDbContext dbContext) : IUserData
    {
        private readonly AppDbContext _dbContext = dbContext;

        #region User listing
        public DbSet<User> GetUsers() => _dbContext.Users;

        #endregion

        #region User creation
        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChangesAsync();
        }

        public void CreateUsers(IEnumerable<User> users)
        {
            _dbContext.Users.AddRange(users);
            _dbContext.SaveChangesAsync();
        }

        #endregion

        public void UpdateUser(User user)
        {
            var updatedUser = this.GetUsers().Find(user.UserId);

            if (updatedUser != null)
            {
                _dbContext.Entry(updatedUser).CurrentValues.SetValues(updatedUser);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public void DeleteUser(User user)
        {
            var deletedUser = this.GetUsers().Find(user.UserId);

            if(deletedUser != null)
            {
                _dbContext.Remove(deletedUser);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
