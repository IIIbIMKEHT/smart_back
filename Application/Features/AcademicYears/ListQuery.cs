using Application.Core;
using Application.Core.DTOs.AcademicDegree;
using Application.Core.DTOs.AcademicYear;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicYears
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<AcademicYearRDTO>>> { }
        public class Handler : IRequestHandler<Query, Response<List<AcademicYearRDTO>>>
        {
            private readonly IAcademicYear _academicYear;
            private readonly IMapper _mapper;

            public Handler(IAcademicYear academicYear, IMapper mapper)
            {
                _academicYear = academicYear;
                _mapper = mapper;
            }
            public async Task<Response<List<AcademicYearRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var years = await _academicYear.ListAllAsync();
                return Response<List<AcademicYearRDTO>>.Success(_mapper.Map<List<AcademicYearRDTO>>(years));
            }
        }
    }
}
