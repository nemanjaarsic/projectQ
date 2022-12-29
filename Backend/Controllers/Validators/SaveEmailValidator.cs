using EmailProject.Controllers.DTO;
using EmailProject.Services;
using FluentValidation;

namespace EmailProject.Controllers.Validators
{
    public class SaveEmailValidator : Validator<EmailDTO>
	{
		private readonly IValidationService _validationService;
		private List<UserDTO> users;

        public override void ValidateAndThrow(EmailDTO instance)
        {
            users = _validationService.GetUsers() ?? new List<UserDTO>();

            base.ValidateAndThrow(instance);
        }

        public SaveEmailValidator(IValidationService validationService)
		{
			_validationService = validationService;

			RuleFor(x => x.From)
				.EmailAddress()
				.NotEmpty()
				.WithMessage("Please provide valid email address.");

			RuleFor(x => x.From)
				.Must(emailAddress =>
				{
					return users?.FirstOrDefault(u => u.Email == emailAddress.Trim()) != null;
				})
				.WithMessage("Email address does not exist.");

            RuleFor(x => x.To)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Please provide valid email address.");

            RuleFor(x => x.To)
                .Must(emailAddress =>
                {
                    return users?.FirstOrDefault(u => u.Email == emailAddress.Trim()) != null;
                })
                .WithMessage("Email address does not exist.");

            RuleForEach(x => x.Cc)
                .NotEmpty()
                .EmailAddress()
                .Must(emailAddress =>
                {
                    return users?.FirstOrDefault(u => u.Email == emailAddress.Trim()) != null;
                })
                .WithMessage("Email address does not exist.");
        }
	}
}

