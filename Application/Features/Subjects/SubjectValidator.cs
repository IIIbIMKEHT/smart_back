using Application.Core.DTOs.Subject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subjects
{
    public class SubjectValidator : AbstractValidator<SubjectCUD>
    {
        public SubjectValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.TitleEn).NotEmpty();
            RuleFor(x => x.DescriptionKz).NotEmpty();
            RuleFor(x => x.DescriptionRu).NotEmpty();
            RuleFor(x => x.DescriptionEn).NotEmpty();
            RuleFor(x => x.CodeKz).NotEmpty();
            RuleFor(x => x.CodeRu).NotEmpty();
            RuleFor(x => x.CodeEn).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
            RuleFor(x => x.AcademicDegreeId).NotEmpty();
        }
    }
}
