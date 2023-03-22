using Application.Core.DTOs.Workload;
using Application.Features.Workloads;
using Infrastructure.Specifications.WorkloadSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class WorkloadController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<WorkloadRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWorkloads()
        {
            var query = new WorkloadSpecification();
            return HandleResult(await Mediator.Send(new ListQuery.Query(query)));
        }

        [HttpPost]
        [ProducesResponseType(typeof(WorkloadRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateWorkload(WorkloadCUD workloadCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { workloadCUD = workloadCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(WorkloadRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateWorkload(long Id, WorkloadCUD workloadCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id= Id, workloadCUD = workloadCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteWorkload(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id= Id }));
        }
    }
}
