using Application.Core;
using Application.Core.DTOs.Role;
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

namespace Application.Features.Roles
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<RoleRDTO>>> { }

        public class Handler : IRequestHandler<Query, Response<List<RoleRDTO>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<List<RoleRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var roles = await _context.Roles.ToListAsync();
                return Response<List<RoleRDTO>>.Success(_mapper.Map<List<RoleRDTO>>(roles));
            }
        }
    }
}
