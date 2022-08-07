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
            ICollection<RecipeViewDto> recipes = await _service.GetAllAsync();

            return this.Ok(recipes);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            RecipeDto recipe = await _service.GetByIdAsync(id);

            return this.Ok(recipe);
        }

        [HttpPost("/create")]
        public async Task<IActionResult> Create(RecipeDto newRecipe)
        {
            int id = await _service.CreateAsync(newRecipe);

            return this.Ok(new { Id = id});
        }

        [HttpPut("/update")]
        public async Task<IActionResult> Update(RecipeDto updatedRecipe)
        {
            await _service.UpdateAsync(updatedRecipe);

            return this.Ok();
        }

        [HttpDelete("/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return this.Ok();
        }
    }
}
