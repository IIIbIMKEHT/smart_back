using Application.Core;
using Application.Core.DTOs.Department;
using Application.Features.Departments;
using Application.Features.Departments.Params;
using Infrastructure.Specifications.DepartmentSpec;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class DepartmentController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<DepartmentRDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetDepartments([FromQuery] DepartmentParameters parameters)
        {
            var spec = new DepartmentSpecification();
            return HandlePagedResult(await Mediator.Send(new ListQuery.Query { _parameters = parameters, _specification = spec}));
        }

        [HttpPost]
        [ProducesResponseType(typeof(DepartmentRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDepartment(DepartmentCUD departmentCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { departmentCUD = departmentCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(DepartmentRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditDepartment(DepartmentCUD departmentCUD, long Id)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { Id = Id, departmentCUD = departmentCUD }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteDepartment(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
