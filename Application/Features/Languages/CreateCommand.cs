using Application.Core;
using Application.Core.DTOs.Language;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities.Systems;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages
{
    public class CreateCommand
    {
        public class Command : IRequest<Response<LanguageRDTO>> 
        {
            public LanguageCUD languageCUD { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<LanguageRDTO>>
        {
            private readonly ILanguage _language;
            private readonly IMapper _mapper;

            public Handler(ILanguage language, IMapper mapper)
            {
                _language = language;
                _mapper = mapper;
            }
            public async Task<Response<LanguageRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var language = _mapper.Map<Language>(request.languageCUD);
                await _language.AddAsync(language);
                return Response<LanguageRDTO>.Success(_mapper.Map<LanguageRDTO>(language));
            }
        }
    }
}
