using Application.Core;
using Application.Core.DTOs.Faculty;
using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faculties
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var faculty = await _context.Faculties.FindAsync(request.Id);
                if (faculty == null)
                {
                    return Response<bool>.Failure("Faculty not found");
                }
                _context.Faculties.Remove(faculty);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Response<bool>.Failure("Failed to delete faculty");
                return Response<bool>.Success(true);
            }
        }
    }
}
