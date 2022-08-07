using Harmony.Common.Mapping;
using Harmony.Recipes.Models;

namespace Harmony.Recipes.Services.DTOs
{
    public class RecipeDto: IMapTo<Recipe>, IMapFrom<Recipe>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Rating { get; set; }
    }
}
