using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.UserDAO
{
    public class UserData(AppDbContext dbContext) : IUserData
    {
        private readonly AppDbContext _dbContext = dbContext;

        #region User listing
        public DbSet<User> GetUsers() => _dbContext.Users;

        public async Task<User?> GetUserById(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        #endregion

        #region User creation
        public async Task CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateUsers(IEnumerable<User> users)
        {
            _dbContext.Users.AddRange(users);
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region User edit
        public async Task UpdateUser(User user)
        {
            var updatedUser = await _dbContext.Users.FindAsync(user.UserId);

            if (updatedUser != null)
            {
                updatedUser.Name = user.Name;
                updatedUser.Email = user.Email;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Usuário não encontrado");
            }
        }
        #endregion

        #region User delete
        public async void DeleteUser(User user)
        {
            var deletedUser = await _dbContext.Users.FindAsync(user.UserId);

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
        #endregion
    }
}
