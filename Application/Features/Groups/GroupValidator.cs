using Application.Core.DTOs.Group;
using Domain.Entities.Systems;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Groups
{
    public class GroupValidator : AbstractValidator<GroupCUD>
    {
        public GroupValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.TitleEn).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
            RuleFor(x => x.SpecializationId).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
            RuleFor(x => x.LanguageId).NotEmpty();
        }
    }
}
