using Application.Core;
using Application.Core.DTOs.Faculty;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Faculties
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<FacultyRDTO>>> { }

        public class Handler : IRequestHandler<Query, Response<List<FacultyRDTO>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<List<FacultyRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var models = await _context.Faculties.ToListAsync();
                return Response<List<FacultyRDTO>>.Success(_mapper.Map<List<FacultyRDTO>>(models));
            }
        }
    }
}
