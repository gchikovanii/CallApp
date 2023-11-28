using CallApp.Domain.Entities;
using FluentValidation;


namespace CallApp.Application.Infrastructure.Validators.UserProfiles
{
    public class UserProfileValidators : AbstractValidator<UserProfile>
    {
        public UserProfileValidators()
        {
            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.PersonalNumber).Length(11).NotEmpty();
        }
    }
}
