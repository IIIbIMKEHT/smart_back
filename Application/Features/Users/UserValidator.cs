using Application.Core.DTOs.User;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users
{
    public class UserValidator : AbstractValidator<UserCUD>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.IIN).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();

        }
    }
}
