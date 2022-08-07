using Harmony.Recipes.Services.Contracts;
using Harmony.Recipes.Services.DTOs;
using Harmony.Recipes.Data;
using Microsoft.EntityFrameworkCore;
using Harmony.Recipes.Models;
using AutoMapper;

namespace Harmony.Recipes.Services.Implementations
{
    public class RecipesService : IRecipesService
    {
        private RecipesDbContext _db;
        private readonly IMapper _mapper;

        public RecipesService(RecipesDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ICollection<RecipeViewDto>> GetAllAsync()
        {
            ICollection<Recipe> recipes =  await _db.Recipes.ToListAsync();
            return _mapper.Map<ICollection<RecipeViewDto>>(recipes);
        }

        public async Task<int> CreateAsync(RecipeDto recipe)
        {
            Recipe dbRecipe = _mapper.Map<Recipe>(recipe);

            await _db.Recipes.AddAsync(dbRecipe);
            await _db.SaveChangesAsync();

            return dbRecipe.Id;
        }

        public async Task UpdateAsync(RecipeDto updatedRecipe)
        {
            Recipe dbRecipe = await _db.Recipes.FirstOrDefaultAsync(r => r.Id == updatedRecipe.Id);
            _mapper.Map(updatedRecipe, dbRecipe);
            _db.Recipes.Update(dbRecipe);
            await _db.SaveChangesAsync();
        }

        public async Task<RecipeDto> GetByIdAsync(int id)
        {
            Recipe dbRecipe = await _db.Recipes.FirstOrDefaultAsync(r => r.Id == id);

            return _mapper.Map<RecipeDto>(dbRecipe);
        }

        public async Task DeleteAsync(int id)
        {
            Recipe recipeToDelete = await _db.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            _db.Recipes.Remove(recipeToDelete);
            await _db.SaveChangesAsync();
        }
    }
}
