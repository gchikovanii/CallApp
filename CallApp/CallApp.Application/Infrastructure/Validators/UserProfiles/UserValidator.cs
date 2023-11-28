﻿using CallApp.Domain.Entities;
using CallApp.Infrastructure.Globalization;
using FluentValidation;


namespace CallApp.Application.Infrastructure.Validators.UserProfiles
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(i => i.Email).EmailAddress().WithMessage(ValidationMessages.IncorrectEmail).NotEmpty();
            RuleFor(i => i.Password).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$").WithMessage(ValidationMessages.Password);
        }
    }
}
