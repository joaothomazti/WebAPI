using Business.Interfaces;
using Data.Models;
using Data.UserDAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserService(IUserData userData) : IUserService
    {
        private readonly IUserData _userData = userData;

        #region User listing
        public async Task<IList<User>> GetUsers()
        {
            return await _userData.GetUsers().ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _userData.GetUsers().FindAsync(id);
        }
        #endregion

        #region User creation

        public void CreateUser(User user)
        {
            _userData.CreateUser(user);
        }

        public void CreateUsers(IEnumerable<User> users)
        {
            _userData.CreateUsers(users);
        }
        #endregion

        public void UpdateUser(User user)
        {
            _userData.UpdateUser(user);
        }

        public void DeleteUser(User user) 
        {
            _userData.DeleteUser(user);
        }
    }
}
