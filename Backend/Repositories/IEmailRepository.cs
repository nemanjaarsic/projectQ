using EmailProject.Repositories.Models;

namespace EmailProject.Repositories
{
	public interface IEmailRepository
	{
        void SaveEmail(Email email);
        IEnumerable<Email> GetEmails(string userEmail);
    }
}

