using Application.Core;
using Application.Core.DTOs.Language;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages
{
    public class ListQuery
    {
        public class Query : IRequest<Response<List<LanguageRDTO>>> { }
        public class Handler : IRequestHandler<Query, Response<List<LanguageRDTO>>>
        {
            private readonly ILanguage _language;
            private readonly IMapper _mapper;

            public Handler(ILanguage language, IMapper mapper)
            {
                _language = language;
                _mapper = mapper;
            }
            public async Task<Response<List<LanguageRDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var languages = await _language.ListAllAsync();
                return Response<List<LanguageRDTO>>.Success(_mapper.Map<List<LanguageRDTO>>(languages));
            }
        }
    }
}
