using Application.Core.DTOs.Role;
using Application.Features.Roles;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class RoleController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<RoleRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoles()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(RoleRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateRole(RoleCUD roleCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { roleCUD = roleCUD}));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(RoleRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditRole(RoleCUD roleCUD, long Id)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, roleCUD = roleCUD}));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRole(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id}));
        }
    }
}
