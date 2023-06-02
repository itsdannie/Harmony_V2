﻿using Harmony.Fitness.Services.Contracts;
using Harmony.Fitness.Services.DTOs;
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
    }
}