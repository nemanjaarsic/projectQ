using EmailProject.Repositories.Models;

namespace EmailProject.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly Context _context;

		public UserRepository(Context context)
		{
            _context = context;
		}

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}

