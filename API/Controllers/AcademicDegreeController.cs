using Application.Core.DTOs.AcademicDegree;
using Application.Features.AcademicDegrees;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class AcademicDegreeController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<AcademicDegreeRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAcademicDegrees()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(AcademicDegreeRDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAcademicDegreeById(long Id)
        {
            return HandleResult(await Mediator.Send(new DetailQuery.Query {Id = Id}));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(AcademicDegreeRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAcademicDegree(AcademicDegreeCUD academicDegreeCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { academicDegree = academicDegreeCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(AcademicDegreeRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateAcademicDegree(long Id, AcademicDegreeCUD academicDegreeCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, academicDegree = academicDegreeCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAcademicDegree(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
