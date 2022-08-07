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

        public async Task<ICollection<RecipeViewDto>> GetAllRecipesAsync()
        {
            ICollection<Recipe> recipes =  await _db.Recipes.ToListAsync();
            return _mapper.Map<ICollection<RecipeViewDto>>(recipes);
        }
    }
}
