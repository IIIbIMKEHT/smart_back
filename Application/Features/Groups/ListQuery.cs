using Application.Core;
using Application.Core.DTOs.Group;
using Application.Core.Interfaces;
using Application.Core.Specification;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Systems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Groups
{
    public class ListQuery
    {
        public class Query : IRequest<Response<PagedList<GroupRDTO>>> 
        {
            public ISpecification<Group> specification;
            public GroupParameters parameters;
        }
        public class Handler : IRequestHandler<Query, Response<PagedList<GroupRDTO>>>
        {
            private readonly IGroup _group;
            private readonly IMapper _mapper;

            public Handler(IGroup group, IMapper mapper)
            {
                _group = group;
                _mapper = mapper;
            }
            public async Task<Response<PagedList<GroupRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var groups = _group.GetQueryable(request.specification);
                var query = groups.ProjectTo<GroupRDTO>(_mapper.ConfigurationProvider);

                return Response<PagedList<GroupRDTO>>.Success(await PagedList<GroupRDTO>.CreateAsync(query, request.parameters.PageNumber, request.parameters.PageSize));
            }
        }
    }
}
