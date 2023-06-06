using Harmony.Fitness.Services.Contracts;
using Harmony.Fitness.Services.DTOs;
using Harmony.Fitness.Services.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmony.Web.Controllers.Fitness
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private IWorkoutsService _workoutsService;

        public WorkoutsController(IWorkoutsService workoutsService)
        {
            this._workoutsService = workoutsService;
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetWorkoutForToday()
        {
            WorkoutDto? workout = await _workoutsService.GetWorkoutForToday();

            return this.Ok(workout);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateWorkout([FromBody] NewWorkoutInputModel input)
        {
            WorkoutDto newWorkout = await _workoutsService.CreateWorkout(input.Date);

            return this.Ok(newWorkout);
        }


        [HttpPut("title/{id}")]
        public async Task<IActionResult> GetWorkoutForToday(int id, [FromBody] WorkoutTitleInputModel input)
        {
            await _workoutsService.UpdateTitle(id, input.Title);
            return this.Ok();
        }
    }
}
