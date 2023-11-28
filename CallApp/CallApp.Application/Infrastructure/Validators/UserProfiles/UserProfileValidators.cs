﻿using CallApp.Domain.Entities;
using CallApp.Infrastructure.Globalization;
using FluentValidation;


namespace CallApp.Application.Infrastructure.Validators.UserProfiles
{
    public class UserProfileValidators : AbstractValidator<UserProfile>
    {
        public UserProfileValidators()
        {
            RuleFor(i => i.FirstName).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(i => i.LastName).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(i => i.PersonalNumber).Length(11).WithMessage(ValidationMessages.PersonalNumber);
        }
    }
}
