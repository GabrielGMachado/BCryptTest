using BCryptTest.Models;

namespace BCryptTest.Repository
{
    public interface IUserRepository
    {
        public void Add(User user);
        public void Update();

    }
}
