using Application.Core;
using Domain.Entities.Systems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Weeks
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<Week>>>
        {

        }

        public class Handler : IRequestHandler<Query, Response<List<Week>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Response<List<Week>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var weeks = await _context.Weeks.ToListAsync();
                return Response<List<Week>>.Success(weeks);
            }
        }
    }
}
