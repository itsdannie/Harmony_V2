using Harmony.Recipes.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Recipes.Services.Contracts
{
    public interface IRecipesService
    {
        Task<ICollection<RecipeViewDto>> GetAllRecipesAsync();
    }
}
