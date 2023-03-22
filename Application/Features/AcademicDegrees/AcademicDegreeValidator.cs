using Application.Core.DTOs.AcademicDegree;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicDegrees
{
    public class AcademicDegreeValidator : AbstractValidator<AcademicDegreeCUD>
    {
        public AcademicDegreeValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.TitleEn).NotEmpty();
        }
    }
}
