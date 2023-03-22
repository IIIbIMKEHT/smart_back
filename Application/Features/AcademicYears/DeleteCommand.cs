using Application.Core;
using Application.Core.DTOs.AcademicYear;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicYears
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Hanlder : IRequestHandler<Command, Response<bool>>
        {
            private readonly IAcademicYear _academicYear;

            public Hanlder(IAcademicYear academicYear)
            {
                _academicYear = academicYear;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var year = await _academicYear.GetByIdAsync(request.Id);
                if (year == null) { return Response<bool>.Failure("Year not found"); }
                await _academicYear.DeleteAsync(year);
                return Response<bool>.Success(true);
            }
        }
    }
}
