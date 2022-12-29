using AutoMapper;
using EmailProject.Controllers.DTO;
using EmailProject.Repositories.Models;

namespace EmailProject.Services.Mappers
{
	public class UserMapper : Profile
	{
		public UserMapper()
		{
            CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
        }
	}
}

