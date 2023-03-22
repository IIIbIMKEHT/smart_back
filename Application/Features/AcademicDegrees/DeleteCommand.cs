using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AcademicDegrees
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>> 
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly IAcademicDegree _academicDegree;

            public Handler(IAcademicDegree academicDegree)
            {
                _academicDegree = academicDegree;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var academicDegree = await _academicDegree.GetByIdAsync(request.Id);
                if (academicDegree == null) { return Response<bool>.Failure("AcademicDegree not found"); }
                await _academicDegree.DeleteAsync(academicDegree);
                return Response<bool>.Success(true);
            }
        }
    }
}
