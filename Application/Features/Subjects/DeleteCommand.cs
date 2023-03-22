using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subjects
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>> 
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly ISubject _subject;

            public Handler(ISubject subject)
            {
                _subject = subject;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var subject = await _subject.GetByIdAsync(request.Id);
                if (subject == null) { return Response<bool>.Failure("Subject not found"); }
                await _subject.DeleteAsync(subject);
                return Response<bool>.Success(true);
            }
        }
    }
}
