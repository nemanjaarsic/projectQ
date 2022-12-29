using AutoMapper;
using EmailProject.Controllers.DTO;
using EmailProject.Repositories.Models;
using EmailProject.Repositories;

namespace EmailProject.Services
{
	public class EmailService : IEmailService
	{
		private readonly IEmailRepository _emailRepository;
		private readonly IMapper _mapper;

		public EmailService(IEmailRepository emailRepository, IMapper mapper)
		{
			_emailRepository = emailRepository;
			_mapper = mapper;
		}

		public void SaveEmail(EmailDTO emailDTO)
		{
			var email = _mapper.Map<Email>(emailDTO);
            email.From = email.From.Trim();
			email.To = email.To.Trim();
			for(int i=0; i< email.Cc.Length; i++)
			{
				email.Cc[i] = email.Cc[i].Trim();
			}
			_emailRepository.SaveEmail(email);
		}

		public List<EmailDTO> GetEmails(string userEmail)
		{
            return _mapper.Map<List<EmailDTO>>(_emailRepository.GetEmails(userEmail).ToList());
		}
	}
}

