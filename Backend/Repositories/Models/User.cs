using System.ComponentModel.DataAnnotations;

namespace EmailProject.Repositories.Models
{
	public class User
	{
		[Key]
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
	}
}

