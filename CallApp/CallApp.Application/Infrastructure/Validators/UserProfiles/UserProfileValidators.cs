using CallApp.Application.Commands.Users;
using CallApp.Infrastructure.Globalization;
using FluentValidation;

namespace CallApp.Application.Infrastructure.Validators.UserProfiles
{
    public class UserProfileValidators : AbstractValidator<CreateProfileCommand>
    {
        public UserProfileValidators()
        {
            RuleFor(i => i.FirstName).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(i => i.LastName).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(i => i.PersonalNumber).Length(11).WithMessage(ValidationMessages.PersonalNumber);
        }
    }
}
