using Data.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        public Task<IList<User>> GetUsers();

        public Task<User?> GetUserById(Guid id);

        public void CreateUser(User user);

        public void CreateUsers(IEnumerable<User> users);

        public void UpdateUser(User user);

        public void DeleteUser(User user);
    }
}
