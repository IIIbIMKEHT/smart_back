using Application.Core.DTOs.Faculty;
using Application.Features.Faculties;
using Domain.Entities.Systems;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class FacultyController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<FacultyRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFaculties()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(FacultyRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateFaculty(FacultyCUD faculty)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { FacultyCUD = faculty }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(FacultyRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateFaculty(long Id, FacultyCUD faculty)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, FacultyCUD = faculty}));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteFaculty(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
