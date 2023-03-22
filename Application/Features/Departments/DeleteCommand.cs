using Application.Core;
using Application.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments
{
    public class DeleteCommand
    {
        public class Command : IRequest<Response<bool>> 
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<bool>>
        {
            private readonly IDepartment _department;

            public Handler(IDepartment department)
            {
                _department = department;
            }
            public async Task<Response<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _department.GetByIdAsync(request.Id);
                if (department == null) { return Response<bool>.Failure("Department doesn't exists"); }
                await _department.DeleteAsync(department);
                return Response<bool>.Success(true);
            }
        }
    }
}
