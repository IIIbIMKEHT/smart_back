using Application.Core;
using Application.Core.DTOs.Profession;
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

namespace Application.Features.Professions
{
    public class ListQuery
    {
        public class Query : IRequest<Response<PagedList<ProfessionRDTO>>> 
        {
            public ISpecification<Profession> _specification;
            public ProfessionParameters parameters;
        }
        public class Handler : IRequestHandler<Query, Response<PagedList<ProfessionRDTO>>>
        {
            private readonly IProfession _profession;
            private readonly IMapper _mapper;

            public Handler(IProfession profession, IMapper mapper)
            {
                _profession = profession;
                _mapper = mapper;
            }
            public async Task<Response<PagedList<ProfessionRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var res = _profession.GetQueryable(request._specification);
                var query = res.ProjectTo<ProfessionRDTO>(_mapper.ConfigurationProvider);
                return Response<PagedList<ProfessionRDTO>>.Success(await PagedList<ProfessionRDTO>.CreateAsync(query, request.parameters.PageNumber, request.parameters.PageSize));
            }
        }
    }
}
