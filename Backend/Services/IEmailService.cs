using EmailProject.Controllers.DTO;

namespace EmailProject.Services
{
	public interface IEmailService
	{
        void SaveEmail(EmailDTO emailDTO);
        List<EmailDTO> GetEmails(string userEmail);
    }
}

