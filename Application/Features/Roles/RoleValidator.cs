using Application.Core.DTOs.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles
{
    public class RoleValidator : FluentValidation.AbstractValidator<RoleCUD>
    {
        public RoleValidator()
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
        }
    }
}
