using System.Net;
using Application.Core;
using Application.Core.DTOs.User;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Systems;

namespace Application.Features.Users
{
    public class CreateCommand
    {
        public class Command : IRequest<Response<UserRDTO>> 
        {
            public List<long> RoleIds { get; set; }
            public UserCUD userCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.userCUD).SetValidator(new UserValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<UserRDTO>>
        {
            private readonly IUser _user;
            private readonly IMapper _mapper;
            private readonly DataContext _context;
            private readonly IRolesUsers _rolesUsers;

            public Handler(IUser user, IMapper mapper, DataContext context, IRolesUsers rolesUsers)
            {
                _user = user;
                _mapper = mapper;
                _context = context;
                _rolesUsers = rolesUsers;
            }
            public async Task<Response<UserRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.userCUD.FacultyId != 0 && request.userCUD.FacultyId != null)
                {
                    var faculty = await _context.Faculties.FindAsync(request.userCUD.FacultyId);
                    if (faculty == null) { return Response<UserRDTO>.Failure("Faculty not found"); }
                }
                if (request.userCUD.DepartmentId != 0 && request.userCUD.DepartmentId != null)
                {
                    var department = await _context.Departments.FindAsync(request.userCUD.DepartmentId);
                    if (department == null) { return Response<UserRDTO>.Failure("Department not found"); }
                }
                if (request.userCUD.GroupId != 0 && request.userCUD.GroupId != null)
                {
                    var group = await _context.Groups.FindAsync(request.userCUD.GroupId);
                    if (group == null) { return Response<UserRDTO>.Failure("Group not found"); }
                }
                var user = _mapper.Map<User>(request.userCUD);
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.userCUD.Password);
                var result = await _user.AddAsync(user);
                foreach (long i in request.RoleIds)
                {
                    var role = await _context.Roles.FindAsync(i);
                    if (role == null) { return Response<UserRDTO>.Failure("Role not found"); }
                    var rolesUsers = new RolesUsers
                    {
                        UserId = result.Id,
                        RoleId = i
                    };
                    await _rolesUsers.AddAsync(rolesUsers);
                }
                return Response<UserRDTO>.Success(_mapper.Map<UserRDTO>(_mapper.Map<UserRDTO>(user)));
            }
        }
    }
}
