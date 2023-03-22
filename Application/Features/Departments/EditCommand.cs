using Application.Core;
using Application.Core.DTOs.Department;
using Application.Core.DTOs.Faculty;
using Application.Core.Interfaces;
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
    public class EditCommand
    {
        public class Command : IRequest<Response<DepartmentRDTO>>
        {
            public long Id { get; set; }
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
                var department = await _context.Departments.FindAsync(request.Id);
                if (department == null) { return Response<DepartmentRDTO>.Failure("Department doesn't exists"); }
                var faculty = await _context.Faculties.FindAsync(request.departmentCUD.FacultyId);
                if (faculty == null) { return Response<DepartmentRDTO>.Failure("Faculty doesn't exists"); }
                _mapper.Map(request.departmentCUD, department);
                department.FacultyId = faculty.Id;
                department.Faculty = faculty;
                var response = _mapper.Map<DepartmentRDTO>(department);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Response<DepartmentRDTO>.Failure("Failed to update department");
                return Response<DepartmentRDTO>.Success(response);
            }
        }
    }
}
