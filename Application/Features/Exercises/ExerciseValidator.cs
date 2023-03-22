using Application.Core.DTOs.Exercise;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exercises
{
    public class ExerciseValidator : AbstractValidator<ExerciseCUD>
    {
        public ExerciseValidator() 
        {
            RuleFor(x => x.TitleKz).NotEmpty();
            RuleFor(x => x.TitleRu).NotEmpty();
            RuleFor(x => x.TitleEn).NotEmpty();
        }
    }
}
