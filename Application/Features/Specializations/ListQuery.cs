using Application.Core;
using Application.Core.DTOs.Specialization;
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

namespace Application.Features.Specializations
{
    public class ListQuery
    {
        public class Query : IRequest<Response<PagedList<SpecializationRDTO>>>
        {
            public ISpecification<Specialization> _specification;
            public SpecializationParameters parameters;
        }

        public class Handler : IRequestHandler<Query, Response<PagedList<SpecializationRDTO>>>
        {
            private readonly ISpecialization _specialization;
            private readonly IMapper _mapper;

            public Handler(ISpecialization specialization, IMapper mapper)
            {
                _specialization = specialization;
                _mapper = mapper;
            }
            public async Task<Response<PagedList<SpecializationRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var specializations = _specialization.GetQueryable(request._specification);
                var query = specializations.ProjectTo<SpecializationRDTO>(_mapper.ConfigurationProvider);
                return Response<PagedList<SpecializationRDTO>>.Success(await PagedList<SpecializationRDTO>.CreateAsync(query, request.parameters.PageNumber, request.parameters.PageSize));
            }
        }
    }
}
