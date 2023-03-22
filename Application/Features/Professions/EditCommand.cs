using Application.Core;
using Application.Core.DTOs.Profession;
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

namespace Application.Features.Professions
{
    public class EditCommand
    {
        public class Command : IRequest<Response<ProfessionRDTO>>
        {
            public long Id { get; set; }
            public ProfessionCUD professionCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command> 
        {
            public CommandValidator() 
            {
                RuleFor(x => x.professionCUD).SetValidator(new ProfessionValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Response<ProfessionRDTO>>
        {
            private readonly IProfession _profession;
            private readonly IMapper _mapper;
            private readonly DataContext _context;

            public Handler(IProfession profession, IMapper mapper, DataContext context)
            {
                _profession = profession;
                _mapper = mapper;
                _context = context;
            }
            public async Task<Response<ProfessionRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var profession = await _profession.GetByIdAsync(request.Id);
                if (profession == null) { return Response<ProfessionRDTO>.Failure("Profession not found"); }
                var derpartment = await _context.Departments.FindAsync(request.professionCUD.DepartmentId);
                if (derpartment == null) { return Response<ProfessionRDTO>.Failure("Department not found"); }
                _mapper.Map(request.professionCUD, profession);
                var response = _mapper.Map<ProfessionRDTO>(profession);
                await _profession.UpdateAsync(profession);
                return Response<ProfessionRDTO>.Success(response);
            }
        }
    }
}
