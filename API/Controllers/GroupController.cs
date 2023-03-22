using Application.Core.DTOs.Group;
using Application.Features.Groups;
using Infrastructure.Specifications.GroupSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class GroupController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<GroupRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetGroups([FromQuery] GroupParameters parameters)
        {
            var spec = new GroupSpecification(); 
            return HandlePagedResult(await Mediator.Send(new ListQuery.Query { specification = spec, parameters = parameters}));
        }

        [HttpPost]
        [ProducesResponseType(typeof(GroupRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateGroup(GroupCUD groupCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { groupCUD = groupCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(GroupRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateGroup(long Id, GroupCUD groupCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, groupCUD = groupCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteGroup(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
