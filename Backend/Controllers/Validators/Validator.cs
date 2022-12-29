using FluentValidation;

namespace EmailProject.Controllers.Validators
{
	public abstract class Validator<T> : AbstractValidator<T>
	{
		public virtual void ValidateAndThrow(T instance)
		{
			this.Validate(instance, options => options.ThrowOnFailures());
		}
	}
}

