namespace Harmony.Fitness.Models
{
    public class ExerciseSuggestion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
        public virtual ICollection<ExerciseSuggestionUnit> ExerciseSuggestionUnits { get; set; } = new List<ExerciseSuggestionUnit>();
    }
}