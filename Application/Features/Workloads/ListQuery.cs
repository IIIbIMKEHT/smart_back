using Application.Core;
using Application.Core.DTOs.Workload;
using Application.Core.Interfaces;
using Application.Core.Specification;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Workloads
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<WorkloadRDTO>>>
        {
            public readonly ISpecification<Workload> _specification;

            public Query(ISpecification<Workload> specification)
            {
                _specification = specification;
            }
        }

        public class Handler : IRequestHandler<Query, Response<List<WorkloadRDTO>>>
        {
            private readonly IWorkload _workload;
            private readonly IMapper _mapper;

            public Handler(IWorkload workload, IMapper mapper)
            {
                _workload = workload;
                _mapper = mapper;
            }
            public async Task<Response<List<WorkloadRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var workloads = await _workload.ListWithSpecAsync(request._specification);
                return Response<List<WorkloadRDTO>>.Success(_mapper.Map<List<WorkloadRDTO>>(workloads));
            }
        }
    }
}
