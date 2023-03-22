using Application.Core;
using Application.Core.DTOs.Role;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Roles
{
    public class EditCommand
    {
        public class Command : IRequest<Response<RoleRDTO>>
        {
            public RoleCUD roleCUD { get; set; }
            public long Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator() 
            {
                RuleFor(x => x.roleCUD).SetValidator(new RoleValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<RoleRDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<RoleRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var role = await _context.Roles.FindAsync(request.Id);
                if (role == null) { return Response<RoleRDTO>.Failure("Role not found"); }
                _mapper.Map(request.roleCUD, role);
                var response = _mapper.Map<RoleRDTO>(role);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) { return Response<RoleRDTO>.Failure("Failed to update role"); }
                return Response<RoleRDTO>.Success(response);
            }
        }
    }
}
