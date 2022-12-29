using EmailProject.Repositories.Models;

namespace EmailProject.Repositories
{
	public class EmailRepository : IEmailRepository
	{
		private readonly Context _context;

		public EmailRepository(Context context)
		{
			_context = context;
		}

		public void SaveEmail(Email email)
		{
			_context.AddAsync(email);
			_context.SaveChangesAsync();
		}

		public IEnumerable<Email> GetEmails(string userEmail)
		{
			return _context.Emails.Where(e => e.From == userEmail);
		}
    }
}

