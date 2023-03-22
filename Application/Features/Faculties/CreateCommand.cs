using Application.Core;
using Application.Core.DTOs.Faculty;
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

namespace Application.Features.Faculties
{
    public class CreateCommand
    {
        public class Command : IRequest<Response<FacultyRDTO>> 
        {
            public FacultyCUD FacultyCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command> 
        {
            public CommandValidator()
            {
                RuleFor(x => x.FacultyCUD).SetValidator(new FacultyValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<FacultyRDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<FacultyRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var models = _mapper.Map<Faculty>(request.FacultyCUD);
                var response = _mapper.Map<FacultyRDTO>(models);
                _context.Faculties.Add(models);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Response<FacultyRDTO>.Failure("Failed to create faculty");
                return Response<FacultyRDTO>.Success(response);
            }
        }
    }
}
