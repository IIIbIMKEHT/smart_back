using Application.Core;
using Application.Core.DTOs.Exercise;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exercises
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<ExerciseRDTO>>> { }
        public class Hanlder : IRequestHandler<Query, Response<List<ExerciseRDTO>>>
        {
            private readonly IExercise _exercise;
            private readonly IMapper _mapper;

            public Hanlder(IExercise exercise, IMapper mapper)
            {
                _exercise = exercise;
                _mapper = mapper;
            }
            public async Task<Response<List<ExerciseRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var exercises = await _exercise.ListAllAsync();
                return Response<List<ExerciseRDTO>>.Success(_mapper.Map<List<ExerciseRDTO>>(exercises));
            }
        }
    }
}
