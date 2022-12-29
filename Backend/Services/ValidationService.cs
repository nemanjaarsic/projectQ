using AutoMapper;
using EmailProject.Controllers.DTO;
using EmailProject.Repositories;

namespace EmailProject.Services
{
	public class ValidationService : IValidationService
	{
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

		public ValidationService(IUserRepository userRepository, IMapper mapper)
		{
            _userRepository = userRepository;
            _mapper = mapper;
		}

        public UserDTO GetUserByEmail(string email)
        {
            return _mapper.Map<UserDTO>(_userRepository.GetUserByEmail(email));
        }

        public List<UserDTO> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(_userRepository.GetUsers());
        }
    }
}

