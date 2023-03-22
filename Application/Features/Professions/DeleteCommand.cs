using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Professions
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>> 
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly IProfession _profession;

            public Handler(IProfession profession)
            {
                _profession = profession;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var profession = await _profession.GetByIdAsync(request.Id);
                if (profession == null) { return Response<bool>.Failure("Profession not found"); }
                await _profession.DeleteAsync(profession);
                return Response<bool>.Success(true);
            }
        }
    }
}
