using Application.Core.DTOs.Specialization;
using Application.Features.Specializations;
using Infrastructure.Specifications.SpecializationSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class SpecializationController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<SpecializationRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSpecializations([FromQuery] SpecializationParameters parameters)
        {
            var query = new SpecializationSpecification();
            return HandlePagedResult(await Mediator.Send(new ListQuery.Query { _specification = query, parameters = parameters}));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SpecializationRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateSpecialization(SpecializationCUD specializationCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { specializationCUD = specializationCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(SpecializationRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSpecialization(long Id, SpecializationCUD specializationCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id,specializationCUD = specializationCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSpecialization(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
