using Application.Core.DTOs.AcademicYear;
using Application.Features.AcademicYears;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class AcademicYear : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<AcademicYearRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetYears()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(AcademicYearRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateYear(AcademicYearCUD academicYearCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { academicYearCUD = academicYearCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(AcademicYearRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateYear(AcademicYearCUD academicYear, long Id)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { academicYearCUD = academicYear, Id = Id }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteYear(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
