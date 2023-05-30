using Harmony.Common.Models.Contracts;

namespace Harmony.Fitness.Models
{
    public class ExerciseProperty
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public string Unit { get; set; }
        public int Value { get; set; }
    }
}