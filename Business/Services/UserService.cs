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

        public async Task<IList<User>> GetUsers()
        {
            return await _userData.GetUsers().AsNoTracking().ToListAsync();
        }

        public User? GetUserById(Guid id)
        {
            return _userData.GetUsers().Find(id);
        }
    }
}
