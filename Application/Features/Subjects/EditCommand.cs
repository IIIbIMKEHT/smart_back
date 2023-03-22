using Application.Core;
using Application.Core.DTOs.Subject;
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

namespace Application.Features.Subjects
{
    public class EditCommand
    {
        public class Command : IRequest<Response<SubjectRDTO>>
        {
            public long Id { get; set; }
            public SubjectCUD subjectCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.subjectCUD).SetValidator(new SubjectValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<SubjectRDTO>>
        {
            private readonly ISubject _subject;
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(ISubject subject, IMapper mapper, DataContext context)
            {
                _subject = subject;
                _mapper = mapper;
                _context = context;
            }
            public async Task<Response<SubjectRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var subject = await _subject.GetByIdAsync(request.Id);
                if (subject == null) { return Response<SubjectRDTO>.Failure("Subject not found"); }
                var department = await _context.Departments.FindAsync(request.subjectCUD.DepartmentId);
                if (department == null) { return Response<SubjectRDTO>.Failure("Department not found"); }
                var academicDegree = await _context.AcademicDegrees.FindAsync(request.subjectCUD.AcademicDegreeId);
                if (academicDegree == null) { return Response<SubjectRDTO>.Failure("AcademicDegree not found"); }
                _mapper.Map(request.subjectCUD, subject);
                await _subject.UpdateAsync(subject);
                return Response<SubjectRDTO>.Success(_mapper.Map<SubjectRDTO>(subject));
            }
        }
    }
}
