using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Models
{
    public class ExerciseSuggestionUnit
    {
        public int ExerciseSuggestionId { get; set; }
        public virtual ExerciseSuggestion ExerciseSuggestion { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
