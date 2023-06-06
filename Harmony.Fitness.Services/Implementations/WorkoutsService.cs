using AutoMapper;
using AutoMapper.QueryableExtensions;
using Harmony.Common.Models.Enums;
using Harmony.Fitness.Data;
using Harmony.Fitness.Models;
using Harmony.Fitness.Services.Contracts;
using Harmony.Fitness.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Services.Implementations
{
    public class WorkoutsService : IWorkoutsService
    {
        private readonly FitnessDbContext _db;
        private readonly IMapper _mapper;

        public WorkoutsService(FitnessDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<WorkoutDto> CreateWorkout(DateTimeOffset date)
        {
            Workout workout = new Workout();
            workout.Date = date;
            workout.Weekday = (Weekday)date.DayOfWeek;
            _db.Workouts.Add(workout);
            await _db.SaveChangesAsync();

            return _mapper.Map<WorkoutDto>(workout);
        }

        public async Task<WorkoutDto?> GetWorkoutForToday()
        {
            DateTime today = DateTime.UtcNow;
            WorkoutDto? workout = await _db.Workouts
                .ProjectTo<WorkoutDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(w => w.Date.Date == today.Date);

            return workout;
        }

        public async Task UpdateTitle(int id, string title)
        {
            Workout? workout = await _db.Workouts
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                throw new ArgumentOutOfRangeException($"No workout was found with id {id}");
            }

            workout.Title = title;

            _db.Update(workout);
            await _db.SaveChangesAsync();
        }
    }
}
