using CallApp.Domain.Entities;
using FluentValidation;


namespace CallApp.Application.Infrastructure.Validators.UserProfiles
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(i => i.Email).EmailAddress().WithMessage("Incorrect Format Of Email").NotEmpty();
            RuleFor(i => i.Password).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$").WithMessage("Password must contain one lowwer case, one uppercase,one number,one special character and must be at least 8 characters length");
        }
    }
}
