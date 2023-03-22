using Application.Features.Weeks;
using Domain.Entities.Systems;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class WeekController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<Week>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWeeks()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }
    }
}
