using EmailProject.Services;
using FluentValidation;

namespace EmailProject.Controllers.Validators
{
	public class IsEmailValid : Validator<string>
	{
		public IsEmailValid(IValidationService validationService)
		{
			RuleFor(x => x)
				.NotEmpty()
				.EmailAddress()
				.WithMessage("Please provide an email address");

			RuleFor(x => x)
				.Must(emailAddress =>
				{
					var user = validationService.GetUserByEmail(emailAddress.Trim());
					return user != null;
				})
				.WithMessage("Provided email address does not exist");
		}
	}
}

