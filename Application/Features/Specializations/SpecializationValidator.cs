using Application.Core.DTOs.Specialization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Specializations
{
    public class SpecializationValidator : AbstractValidator<SpecializationCUD>
    {
        public SpecializationValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.TitleEn).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.ProfessionId).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
        }
    }
}
