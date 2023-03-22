using Application.Core;
using Application.Core.DTOs.AcademicDegree;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities.Systems;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicDegrees
{
    public class CreateCommand
    {
        public class Command : IRequest<Response<AcademicDegreeRDTO>>
        {
            public AcademicDegreeCUD academicDegree { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator() 
            {
                RuleFor(x => x.academicDegree).SetValidator(new AcademicDegreeValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<AcademicDegreeRDTO>>
        {
            private readonly IAcademicDegree _academicDegree;
            private readonly IMapper _mapper;

            public Handler(IAcademicDegree academicDegree, IMapper mapper)
            {
                _academicDegree = academicDegree;
                _mapper = mapper;
            }
            public async Task<Response<AcademicDegreeRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var academicDegrees = _mapper.Map<AcademicDegree>(request.academicDegree);
                await _academicDegree.AddAsync(academicDegrees);
                return Response<AcademicDegreeRDTO>.Success(_mapper.Map<AcademicDegreeRDTO>(academicDegrees));
            }
        }
    }
}
