using Application.Core;
using Application.Core.DTOs.Department;
using Application.Core.DTOs.Faculty;
using Application.Core.Interfaces;
using Application.Core.Specification;
using AutoMapper;
using Domain.Entities.Systems;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments
{
    public class CreateCommand
    {
        public class Command : IRequest<Response<DepartmentRDTO>>
        {
            public DepartmentCUD departmentCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator() 
            {
                RuleFor(x => x.departmentCUD).SetValidator(new DepartmentValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<DepartmentRDTO>>
        {
            private readonly IDepartment _department;
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(IDepartment department, IMapper mapper, DataContext context)
            {
                _department = department;
                _mapper = mapper;
                _context = context;
            }
            public async Task<Response<DepartmentRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var faculty = await _context.Faculties.FindAsync(request.departmentCUD.FacultyId);
                if (faculty == null) { return Response<DepartmentRDTO>.Failure("Faculty doesn't exists"); }
                var department = _mapper.Map<Department>(request.departmentCUD);
                department.FacultyId = faculty.Id;
                department.Faculty = faculty;
                var response = _mapper.Map<DepartmentRDTO>(department);
                await _department.AddAsync(department);
                return Response<DepartmentRDTO>.Success(response);
            }
        }
    }
}
