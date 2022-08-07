using Harmony.Recipes.Services.Contracts;
using Harmony.Recipes.Services.DTOs;
using Harmony.Recipes.Services.Implementations;
using Harmony.Recipes.Data;
using Harmony.Recipes.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Harmony.Common.Testing.Fixtures;
using AutoMapper;

namespace Harmony.Recipes.Tests.Systems.Services
{
    public class RecipesServiceTest
    {

        [Fact]
        public async Task GetAllRecipesAsync_OnSuccess_ReturnRecipesList()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);

            //Act
            ICollection<RecipeViewDto> recipes = await sut.GetAllRecipesAsync();

            //Assert
            recipes.Should().NotBeEmpty();
        }

    }
}
