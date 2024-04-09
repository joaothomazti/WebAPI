using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Business.Interfaces
{
    public interface IUserService
    {
        public Task<IList<User>> GetUsers();

        public User? GetUserById(Guid id);
    }
}
