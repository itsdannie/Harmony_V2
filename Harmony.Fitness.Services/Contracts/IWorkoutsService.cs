using Harmony.Fitness.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Services.Contracts
{
    public interface IWorkoutsService
    {
        Task<WorkoutDto?> GetWorkoutForToday();
        Task UpdateTitle(int id, string title);
        Task<WorkoutDto> CreateWorkout(DateTimeOffset date);
    }
}
