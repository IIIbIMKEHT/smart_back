using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Groups
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly IGroup _group;

            public Handler(IGroup group)
            {
                _group = group;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var group = await _group.GetByIdAsync(request.Id);
                if (group == null) { return Response<bool>.Failure("Group not found"); }
                await _group.DeleteAsync(group);
                return Response<bool>.Success(true);
            }
        }
    }
}
