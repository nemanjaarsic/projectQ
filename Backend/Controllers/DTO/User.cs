using System.ComponentModel.DataAnnotations;

namespace EmailProject.Controllers.DTO
{
	public class UserDTO
	{
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
    }
}

