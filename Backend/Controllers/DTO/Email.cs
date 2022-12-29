namespace EmailProject.Controllers.DTO
{
	public class EmailDTO
	{
        public string From { get; set; }
        public string To { get; set; }
        public IEnumerable<string> Cc { get; set; } = new List<string>();
        public string Subject { get; set; }
        public EmailImportanceDTO Importance { get; set; }
        public string Content { get; set; }
    }

    public enum EmailImportanceDTO
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}

