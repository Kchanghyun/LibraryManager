using LibraryManager.Interfaces;
using LibraryManager.Model;

namespace LibraryManager.Service
{
    public class UserManager : IUserManager {
        private List<User> _users = new();

        private int _nextUserId = 1;

        public void AddUser(User user)
        {
            user.Id = _nextUserId++;
            _users.Add(user);
        }

        public void UpdateUser(User user) { }

        public void RemoveUser(int userId)
        {
            User? user = _users.FirstOrDefault(b => b.Id == userId);
            if (user != null) _users.Remove(user);
        }

        public User FindUserById(int userId)
        {
            return _users.FirstOrDefault(b => b.Id == userId);
        }

        public void LoanService() {

        }
    }
}
