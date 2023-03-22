using Application.Core;
using Application.Core.DTOs.Workload;
using Application.Core.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Workloads
{
    public class EditCommand
    {
        public class Command : IRequest<Response<WorkloadRDTO>>
        {
            public long Id { get; set; }
            public WorkloadCUD workloadCUD { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.workloadCUD.UserId).NotEmpty();
                RuleFor(x => x.workloadCUD.LanguageId).NotEmpty();
                RuleFor(x => x.workloadCUD.AcademicYearId).NotEmpty();
                RuleFor(x => x.workloadCUD.DepartmentId).NotEmpty();
                RuleFor(x => x.workloadCUD.SubjectId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Response<WorkloadRDTO>>
        {
            private readonly IWorkload _workload;
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(IWorkload workload, IMapper mapper, DataContext context)
            {
                _workload = workload;
                _mapper = mapper;
                _context = context;
            }
            public async Task<Response<WorkloadRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var workload = await _workload.GetByIdAsync(request.Id);
                if (workload == null) { return Response<WorkloadRDTO>.Failure("Workload not found"); }
                var user = await _context.Users.FindAsync(request.workloadCUD.UserId);
                if (user == null) { return Response<WorkloadRDTO>.Failure("User not found"); }
                var language = await _context.Languages.FindAsync(request.workloadCUD.LanguageId);
                if (language == null) { return Response<WorkloadRDTO>.Failure("Language not found"); }
                var year = await _context.AcademicYears.FindAsync(request.workloadCUD.AcademicYearId);
                if (year == null) { return Response<WorkloadRDTO>.Failure("Year not found"); }
                var department = await _context.Departments.FindAsync(request.workloadCUD.DepartmentId);
                if (department == null) { return Response<WorkloadRDTO>.Failure("Department not found"); }
                var subject = await _context.Subjects.FindAsync(request.workloadCUD.SubjectId);
                if (subject == null) { return Response<WorkloadRDTO>.Failure("Subject not found"); }
                _mapper.Map(request.workloadCUD, workload);
                await _workload.UpdateAsync(workload);
                return Response<WorkloadRDTO>.Success(_mapper.Map<WorkloadRDTO>(workload));
            }
        }
    }
}
