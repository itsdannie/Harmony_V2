using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ExerciseSuggestion> ExerciseSuggestions { get; set; } = new List<ExerciseSuggestion>();
        public virtual ICollection<ExerciseSuggestionUnit> ExerciseSuggestionUnits { get; set; } = new List<ExerciseSuggestionUnit>();

    }
}
