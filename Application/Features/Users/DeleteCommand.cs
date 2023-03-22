using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly IUser _user;

            public Handler(IUser user)
            {
                _user = user;
            }

            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _user.GetByIdAsync(request.Id);
                if (user == null) { return Response<bool>.Failure("User not found"); }
                await _user.DeleteAsync(user);
                return Response<bool>.Success(true);
            }
        }
    }
}
