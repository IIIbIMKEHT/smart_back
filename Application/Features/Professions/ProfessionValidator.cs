using Application.Core.DTOs.Profession;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Professions
{
    public class ProfessionValidator : AbstractValidator<ProfessionCUD>
    {
        public ProfessionValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.TitleEn).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
}
