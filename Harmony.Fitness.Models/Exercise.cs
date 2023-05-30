using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkoutId { get; set; }
        public virtual Workout Workout { get; set; }
        public virtual ICollection<ExerciseProperty> Properties { get; set; } = new List<ExerciseProperty>();
    }
}
