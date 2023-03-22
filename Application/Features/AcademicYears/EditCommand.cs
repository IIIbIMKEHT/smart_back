using Application.Core;
using Application.Core.DTOs.AcademicYear;
using Application.Core.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicYears
{
    public class EditCommand
    {
        public class Command : IRequest<Response<AcademicYearRDTO>>
        {
            public long Id { get; set; }
            public AcademicYearCUD academicYearCUD { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.academicYearCUD.Year).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Response<AcademicYearRDTO>>
        {
            private readonly IAcademicYear _academicYear;
            private readonly IMapper _mapper;

            public Handler(IAcademicYear academicYear, IMapper mapper)
            {
                _academicYear = academicYear;
                _mapper = mapper;
            }
            public async Task<Response<AcademicYearRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var year = await _academicYear.GetByIdAsync(request.Id);
                if (year == null) { return Response<AcademicYearRDTO>.Failure("Year not found"); }
                _mapper.Map(request.academicYearCUD, year);
                await _academicYear.UpdateAsync(year);
                return Response<AcademicYearRDTO>.Success(_mapper.Map<AcademicYearRDTO>(year));
            }
        }
    }
}
