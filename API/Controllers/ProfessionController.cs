using Application.Core.DTOs.Profession;
using Application.Features.Professions;
using Infrastructure.Specifications.ProfessionSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class ProfessionController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<ProfessionRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProfessions([FromQuery] ProfessionParameters parameters)
        {
            var query = new ProfessionSpecification();
            return HandlePagedResult(await Mediator.Send(new ListQuery.Query { _specification = query, parameters = parameters}));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProfessionRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProf(ProfessionCUD professionCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { professionCUD = professionCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(ProfessionRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProf(long Id, ProfessionCUD professionCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, professionCUD = professionCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProf(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }

    }
}
