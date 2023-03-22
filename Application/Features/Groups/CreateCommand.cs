using Application.Core;
using Application.Core.DTOs.Group;
using Application.Core.Interfaces;
using AutoMapper;
using Domain.Entities.Systems;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Groups
{
    public class CreateCommand
    {
        public class Command : IRequest<Response<GroupRDTO>> 
        {
            public GroupCUD groupCUD { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator() 
            {
                RuleFor(x => x.groupCUD).SetValidator(new GroupValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Response<GroupRDTO>>
        {
            private readonly IGroup _group;
            private readonly IMapper _mapper;
            private readonly IDepartment _department;
            private readonly ILanguage _language;

            public Handler(IGroup group, IMapper mapper, IDepartment department, ILanguage language)
            {
                _group = group;
                _mapper = mapper;
                _department = department;
                _language = language;
            }
            public async Task<Response<GroupRDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _department.GetByIdAsync(request.groupCUD.DepartmentId);
                if (department == null) { return Response<GroupRDTO>.Failure("Department not found"); }
                var language = await _language.GetByIdAsync(request.groupCUD.LanguageId);
                if (language == null) { return Response<GroupRDTO>.Failure("Language not found"); }
                var group = _mapper.Map<Group>(request.groupCUD);
                await _group.AddAsync(group);
                return Response<GroupRDTO>.Success(_mapper.Map<GroupRDTO>(group));
            }
        }
    }
}
