using Application.Core;
using Application.Core.DTOs.Exercise;
using Application.Core.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exercises
{
    public class EditCommand
    {
        public class Command : IRequest<Response<ExerciseRDTO>>
        {
            public long Id { get; set; }
            public ExerciseCUD exerciseCUD { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator() 
            {
                RuleFor(x => x.exerciseCUD).SetValidator(new ExerciseValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<ExerciseRDTO>>
        {
            private readonly IExercise _exercise;
            private readonly IMapper _mapper;

            public Handler(IExercise exercise, IMapper mapper)
            {
                _exercise = exercise;
                _mapper = mapper;
            }
            public async Task<Response<ExerciseRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var exercise = await _exercise.GetByIdAsync(request.Id);
                if (exercise == null) { return Response<ExerciseRDTO>.Failure("Exercise not found"); }
                _mapper.Map(request.exerciseCUD, exercise);
                await _exercise.UpdateAsync(exercise);
                return Response<ExerciseRDTO>.Success(_mapper.Map<ExerciseRDTO>(exercise));
            }
        }
    }
}
