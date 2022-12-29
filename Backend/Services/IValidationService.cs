using EmailProject.Controllers.DTO;

namespace EmailProject.Services
{
	public interface IValidationService
	{
		List<UserDTO> GetUsers();
		UserDTO GetUserByEmail(string email);
	}
}

