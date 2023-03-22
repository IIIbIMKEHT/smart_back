using Application.Core.DTOs.Faculty;
using Domain.Entities.Systems;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faculties
{
    public class FacultyValidator : AbstractValidator<FacultyCUD>
    {
        public FacultyValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
        }
    }
}
