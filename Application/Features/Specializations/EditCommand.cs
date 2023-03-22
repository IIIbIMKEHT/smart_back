using Application.Core;
using Application.Core.DTOs.Specialization;
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

namespace Application.Features.Specializations
{
    public class EditCommand
    {
        public class Command : IRequest<Response<SpecializationRDTO>>
        {
            public long Id { get; set; }
            public SpecializationCUD specializationCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator() 
            {
                RuleFor(x => x.specializationCUD).SetValidator(new SpecializationValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<SpecializationRDTO>>
        {
            private readonly ISpecialization _specialization;
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(ISpecialization specialization, IMapper mapper, DataContext context)
            {
                _specialization = specialization;
                _mapper = mapper;
                _context = context;
            }
            public async Task<Response<SpecializationRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var spec = await _specialization.GetByIdAsync(request.Id);
                if (spec == null) { return Response<SpecializationRDTO>.Failure("Specialization not found"); }
                var prof = await _context.Professions.FindAsync(request.specializationCUD.ProfessionId);
                if (prof == null) { return Response<SpecializationRDTO>.Failure("Profession not found"); }
                var department = await _context.Departments.FindAsync(request.specializationCUD.DepartmentId);
                if (department == null) { return Response<SpecializationRDTO>.Failure("Department not found"); }
                _mapper.Map(request.specializationCUD, spec);
                await _specialization.UpdateAsync(spec);
                return Response<SpecializationRDTO>.Success(_mapper.Map<SpecializationRDTO>(spec));
            }
        }
    }
}
