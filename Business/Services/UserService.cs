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
            return await _userData.GetUsers().AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _userData.GetUserById(id);
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

        #region User edit
        public async Task UpdateUser(User user)
        {
            await _userData.UpdateUser(user);
        }
        #endregion

        #region User delete
        public void DeleteUser(User user) 
        {
             _userData.DeleteUser(user);
        }
        #endregion
    }
}
