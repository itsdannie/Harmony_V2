using Harmony.Recipes.Data;
using Harmony.Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Recipes.Tests.Fixtures
{
    public static class RecipesFixtures
    {
        public static async Task<RecipesDbContext> SeedRecipes(this RecipesDbContext dbContext)
        {
            ICollection<Recipe> recipes = new List<Recipe>
            {
                new() { Id = 1, Title = "Potatoes", Rating =  3 },
                new() { Id = 2, Title = "Cupcakes", Rating =  5 },
                new() { Id = 3, Title = "Fritata", Rating =  1 },
            };

            await dbContext.Recipes.AddRangeAsync(recipes);
            await dbContext.SaveChangesAsync();

            return dbContext;
        }
    }
}
