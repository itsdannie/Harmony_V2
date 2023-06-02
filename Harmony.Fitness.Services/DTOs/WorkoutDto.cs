using Harmony.Common.Mapping;
using Harmony.Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Services.DTOs
{
    public class WorkoutDto: IMapFrom<Workout>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Weekday { get; set; }
        public DateTimeOffset Date { get; set; }
        public ICollection<ExerciseDto> Exercises { get; set; }
    }
}
