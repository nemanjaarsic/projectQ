using EmailProject.Repositories.Models;

namespace EmailProject.Repositories
{
	public interface IUserRepository
	{
        IEnumerable<User> GetUsers();
		User GetUserByEmail(string email);
	}
}

