using Application.Core.DTOs.User;
using Application.Features.Users;
using Infrastructure.Specifications.UserSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<UserRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var query = new UserSpecification();
            return HandleResult(await Mediator.Send(new ListQuery.Query(query)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateUser([FromQuery]List<long> RoleIds, UserCUD userCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { RoleIds = RoleIds, userCUD = userCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(UserRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUser(long Id, [FromQuery]List<long> RoleIds, UserCUD userCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, RoleIds = RoleIds, userCUD = userCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
