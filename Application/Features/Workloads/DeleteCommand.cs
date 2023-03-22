using Application.Core;
using Application.Core.DTOs.Workload;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Workloads
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly IWorkload _workload;

            public Handler(IWorkload workload)
            {
                _workload = workload;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var workload = await _workload.GetByIdAsync(request.Id);
                if (workload == null) { return Response<bool>.Failure("Workload not found"); }
                await _workload.DeleteAsync(workload);
                return Response<bool>.Success(true);
            }
        }
    }
}
