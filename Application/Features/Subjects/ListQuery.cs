using Application.Core;
using Application.Core.DTOs.Subject;
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

namespace Application.Features.Subjects
{
    public class ListQuery
    {
        public class Query : IRequest<Response<PagedList<SubjectRDTO>>> 
        {
            public ISpecification<Subject> _specification;
            public SubjectParameters parameters;
        }
        public class Handler : IRequestHandler<Query, Response<PagedList<SubjectRDTO>>>
        {
            private readonly ISubject _subject;
            private readonly IMapper _mapper;

            public Handler(ISubject subject, IMapper mapper)
            {
                _subject = subject;
                _mapper = mapper;
            }
            public async Task<Response<PagedList<SubjectRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var subjects = _subject.GetQueryable(request._specification);
                var query = subjects.ProjectTo<SubjectRDTO>(_mapper.ConfigurationProvider);
                return Response<PagedList<SubjectRDTO>>.Success(await PagedList<SubjectRDTO>.CreateAsync(query, request.parameters.PageNumber, request.parameters.PageSize));
            }
        }
    }
}
