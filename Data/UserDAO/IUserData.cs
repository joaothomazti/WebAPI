using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.UserDAO
{
    public interface IUserData
    {
        #region User listing 
        DbSet<User> GetUsers();

        Task<User?> GetUserById(Guid id);
        #endregion

        #region User creation
        Task CreateUser(User user);

        Task CreateUsers(IEnumerable<User> users);
        #endregion

        #region User edit
        Task UpdateUser(User user);
        #endregion

        #region User delete
        void DeleteUser(User user);
        #endregion
    }
}
