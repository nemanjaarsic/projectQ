using AutoMapper;
using EmailProject.Controllers.DTO;
using EmailProject.Repositories.Models;

namespace EmailProject.Services.Mappers
{
	public class EmailMapper : Profile
	{
		public EmailMapper()
		{
            CreateMap<Email, EmailDTO>();
            CreateMap<EmailDTO, Email>();
        }
	}
}

