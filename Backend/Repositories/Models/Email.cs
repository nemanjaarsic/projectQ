using System.ComponentModel.DataAnnotations;

namespace EmailProject.Repositories.Models
{
	public class Email
	{
        [Key]
		public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string[] Cc { get; set; }
		public string Subject { get; set; }
		public EmailImportance Importance { get; set; }
		public string Content { get; set; }

	}
}

