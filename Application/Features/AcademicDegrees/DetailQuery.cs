using Application.Core;
using Application.Core.DTOs.AcademicDegree;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.AcademicDegrees;

public class DetailQuery
{
    public class Query : IRequest<Response<AcademicDegreeRDTO>>
    {
        public long Id { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, Response<AcademicDegreeRDTO>>
    {
        private readonly IAcademicDegree _degree;
        private readonly IMapper _mapper;

        public Handler(IAcademicDegree degree, IMapper mapper)
        {
            _degree = degree;
            _mapper = mapper;
        }
        
        public async Task<Response<AcademicDegreeRDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var academicDegree = await _degree.GetByIdAsync(request.Id);
            if (academicDegree == null) { return Response<AcademicDegreeRDTO>.Failure("AcademicDegree not found"); }

            return Response<AcademicDegreeRDTO>.Success(_mapper.Map<AcademicDegreeRDTO>(academicDegree));
        }
    }
}