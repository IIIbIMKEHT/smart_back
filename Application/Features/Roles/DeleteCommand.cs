using Application.Core;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>> 
        {
            public long Id { get; set; }
        }

        public class Hanlder : IRequestHandler<Command, Response<bool>>
        {
            private readonly DataContext _context;

            public Hanlder(DataContext context)
            {
                _context = context;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var role = await _context.Roles.FindAsync(request.Id);
                if (role == null) { return Response<bool>.Failure("Role not found"); }
                _context.Roles.Remove(role);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) { return Response<bool>.Failure("Failed to delete role"); }
                return Response<bool>.Success(result);
            }
        }
    }
}
