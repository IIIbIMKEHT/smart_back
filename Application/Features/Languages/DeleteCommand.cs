using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>>
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly ILanguage _language;

            public Handler(ILanguage language)
            {
                _language = language;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var language = await _language.GetByIdAsync(request.Id);
                if (language == null) { return Response<bool>.Failure("Language not found"); }
                await _language.DeleteAsync(language);
                return Response<bool>.Success(true);
            }
        }
    }
}
