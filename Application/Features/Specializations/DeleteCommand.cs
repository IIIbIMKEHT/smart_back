using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Specializations
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly ISpecialization _specialization;

            public Handler(ISpecialization specialization)
            {
                _specialization = specialization;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var spec = await _specialization.GetByIdAsync(request.Id);
                if (spec == null) { return Response<bool>.Failure("Specialization not found"); }
                await _specialization.DeleteAsync(spec);
                return Response<bool>.Success(true);
            }
        }
    }
}
