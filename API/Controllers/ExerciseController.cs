using Application.Core.DTOs.Exercise;
using Application.Features.Exercises;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class ExerciseController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<ExerciseRDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetExercises()
        {
            return HandleResult(await Mediator.Send(new ListQuery.Query()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExerciseRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateExercise(ExerciseCUD exerciseCUD)
        {
            return HandleResult(await Mediator.Send(new CreateCommand.Command { exerciseCUD = exerciseCUD }));
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(ExerciseRDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateExercise(long Id, ExerciseCUD exerciseCUD)
        {
            return HandleResult(await Mediator.Send(new EditCommand.Command { exerciseCUD = exerciseCUD, Id = Id }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteExercise(long Id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommand.Command { Id = Id }));
        }
    }
}
