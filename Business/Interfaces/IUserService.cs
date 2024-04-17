using Data.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        #region User Listing
        Task<IList<User>> GetUsers();

        Task<User?> GetUserById(Guid id);
        #endregion

        #region User creation
        void CreateUser(User user);

        void CreateUsers(IEnumerable<User> users);
        #endregion

        #region User edit
        Task UpdateUser(User user);
        #endregion

        #region User delete
        void DeleteUser(User user);
        #endregion
    }
}
