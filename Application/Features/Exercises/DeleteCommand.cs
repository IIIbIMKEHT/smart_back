using Application.Core;
using Application.Core.DTOs.Exercise;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exercises
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Hanlder : IRequestHandler<Command, Response<bool>>
        {
            private readonly IExercise _exercise;

            public Hanlder(IExercise exercise)
            {
                _exercise = exercise;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var exercise = await _exercise.GetByIdAsync(request.Id);
                if (exercise == null) { return Response<bool>.Failure("Exercise not found"); }
                await _exercise.DeleteAsync(exercise);
                return Response<bool>.Success(true);
            }
        }
    }
}
