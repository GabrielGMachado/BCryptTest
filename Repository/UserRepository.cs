using BCryptTest.Context;
using BCryptTest.Models;

namespace BCryptTest.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext userContext)
        {
            _dbContext = userContext;
        }
        public void Add(User user)
        {
            _dbContext.users.Add(user);
        }

        public void Update() 
        {
            _dbContext.SaveChanges();
        }

    }
}
