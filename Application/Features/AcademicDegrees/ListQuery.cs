using Application.Core;
using Application.Core.DTOs.AcademicDegree;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicDegrees
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<AcademicDegreeRDTO>>> { }
        public class Handler : IRequestHandler<Query, Response<List<AcademicDegreeRDTO>>>
        {
            private readonly IAcademicDegree _academicDegree;
            private readonly IMapper _mapper;

            public Handler(IAcademicDegree academicDegree, IMapper mapper)
            {
                _academicDegree = academicDegree;
                _mapper = mapper;
            }
            public async Task<Response<List<AcademicDegreeRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var academicDegrees = await _academicDegree.ListAllAsync();
                return Response<List<AcademicDegreeRDTO>>.Success(_mapper.Map<List<AcademicDegreeRDTO>>(academicDegrees));
            }
        }
    }
}
