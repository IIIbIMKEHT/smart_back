using Application.Core.DTOs.Department;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments
{
    public class DepartmentValidator : AbstractValidator<DepartmentCUD>
    {
        public DepartmentValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.FacultyId).NotEmpty();
        }
    }
}
