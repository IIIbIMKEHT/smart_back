using Application.Core;
using Application.Core.DTOs.Department;
using Application.Core.Specification;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using Application.Core.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Departments.Params;
using AutoMapper.QueryableExtensions;

namespace Application.Features.Departments
{
    public class ListQuery
    {
        public class Query : IRequest<Response<PagedList<DepartmentRDTO>>> 
        {
            public ISpecification<Department> _specification;
            public DepartmentParameters _parameters;
        }

        public class Handler : IRequestHandler<Query, Response<PagedList<DepartmentRDTO>>>
        {
            private readonly IDepartment _department;
            private readonly IMapper _mapper;

            public Handler(IDepartment department, IMapper mapper)
            {
                _department = department;
                _mapper = mapper;
            }
            public async Task<Response<PagedList<DepartmentRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var res = _department.GetQueryable(request._specification);
                var query = _mapper.ProjectTo<DepartmentRDTO>(res).AsQueryable();
                
                return Response<PagedList<DepartmentRDTO>>.Success(await PagedList<DepartmentRDTO>.CreateAsync(query, request._parameters.PageNumber, request._parameters.PageSize));
            }
        }
    }
}
