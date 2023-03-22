using Application.Core;
using Application.Core.DTOs.Faculty;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faculties
{
    public class EditCommand
    {
        public class Command : IRequest<Response<FacultyRDTO>> 
        {
            [Required]
            public long Id { get; set; }
            [Required]
            public FacultyCUD FacultyCUD { get; set; }
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
                var faculty = await _context.Faculties.FindAsync(request.Id);
                _mapper.Map(request.FacultyCUD, faculty);
                var response = _mapper.Map<FacultyRDTO>(faculty);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Response<FacultyRDTO>.Failure("Failed to update faculty");
                return Response<FacultyRDTO>.Success(response);
            }
        }
    }
}
