using Application.Core.DTOs.Subject;
using Application.Features.Subjects;
using Infrastructure.Specifications.SubjectSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class SubjectController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<SubjectRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSubjects([FromQuery] SubjectParameters parameters)
        {
            var query = new SubjectSpecification();
            return HandlePagedResult(await Mediator.Send(new ListQuery.Query { _specification = query, parameters = parameters }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SubjectRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateSubject(SubjectCUD subjectCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { subjectCUD = subjectCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(SubjectRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSubject(long Id, SubjectCUD subjectCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, subjectCUD = subjectCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSubject(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id}));
        }
    }
}
