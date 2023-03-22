using Application.Core;
using Application.Core.DTOs.User;
using Application.Core.Interfaces;
using Application.Core.Specification;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<UserRDTO>>> 
        {
            public readonly ISpecification<User> _specification;

            public Query(ISpecification<User> specification)
            {
                _specification = specification;
            }
        }

        public class Handler : IRequestHandler<Query, Response<List<UserRDTO>>>
        {
            private readonly IUser _user;
            private readonly IMapper _mapper;

            public Handler(IUser user, IMapper mapper)
            {
                _user = user;
                _mapper = mapper;
            }
            public async Task<Response<List<UserRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _user.ListWithSpecAsync(request._specification);
                return Response<List<UserRDTO>>.Success(_mapper.Map<List<UserRDTO>>(users));
            }
        }
    }
}
