using Harmony.Recipes.Services.Contracts;
using Harmony.Recipes.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmony.Web.Controllers.Recipes
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _service;

        public RecipesController(IRecipesService service)
        {
            _service = service;
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAllRecipes()
        {
            ICollection<RecipeViewDto> recipes = await _service.GetAllRecipesAsync();

            return this.Ok(recipes);
        }
    }
}
