using Application.Core;
using Application.Core.DTOs.Language;
using Application.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages
{
    public class EditCommand
    {
        public class Command : IRequest<Response<LanguageRDTO>>
        {
            public long Id { get; set; }
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
                var language = await _language.GetByIdAsync(request.Id);
                if (language == null) { return Response<LanguageRDTO>.Failure("Language not found"); }
                _mapper.Map(request.languageCUD, language);
                await _language.UpdateAsync(language);
                return Response<LanguageRDTO>.Success(_mapper.Map<LanguageRDTO>(language));
            }
        }
    }
}
