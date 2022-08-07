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
using Microsoft.EntityFrameworkCore;
using Harmony.Recipes.Models;

namespace Harmony.Recipes.Tests.Systems.Services
{
    public class RecipesServiceTest
    {

        [Fact]
        public async Task GetAllAsync_OnSuccess_ReturnRecipesList()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);

            //Act
            ICollection<RecipeViewDto> recipes = await sut.GetAllAsync();

            //Assert
            recipes.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_OnSuccess_ReturnOnlyNotDeleted()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);

            //Act
            ICollection<RecipeViewDto> recipes = await sut.GetAllAsync();

            //Assert
            ICollection<int> deletedRecipesIds = await inMemoryDb.Recipes
                .Where(r => r.IsDeleted)
                .Select(r => r.Id)
                .ToListAsync();
            recipes.Any(r => deletedRecipesIds.Contains(r.Id)).Should().BeFalse();
        }


        [Fact]
        public async Task CreateAsync_OnSuccess_ReturnId()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);

            RecipeDto recipe = new RecipeDto
            {
                Title = Guid.NewGuid().ToString(),
            };

            //Act
            int recipeId = await sut.CreateAsync(recipe);

            //Assert
            Recipe createdRecipe = await inMemoryDb.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);
            createdRecipe.Should().NotBeNull();
            createdRecipe.Title.Should().Be(recipe.Title);
        }

        [Fact]
        public async Task UpdateAsync_OnSuccess_UpdateRecipe()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);
            Recipe testRecipe = await inMemoryDb.Recipes.FirstAsync();
            testRecipe.Title = Guid.NewGuid().ToString();
            RecipeDto dto = mapper.Map<RecipeDto>(testRecipe);

            //Act
            await sut.UpdateAsync(dto);

            //Assert
            Recipe updatedRecipe = await inMemoryDb.Recipes.FirstAsync(r => r.Id == testRecipe.Id);
            updatedRecipe.Title.Should().Be(testRecipe.Title);
        }

        [Fact]
        public async Task GetByIdAsync_OnSuccess_ReturnRecipe()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);
            Recipe testRecipe = await inMemoryDb.Recipes.FirstAsync();

            //Act
            RecipeDto result = await sut.GetByIdAsync(testRecipe.Id);

            //Assert
            result.Title.Should().Be(testRecipe.Title);
            result.Id.Should().Be(testRecipe.Id);
        }

        [Fact]
        public async Task DeleteAsync_OnSuccess_SoftDelete()
        {
            //Arrange
            RecipesDbContext inMemoryDb = await DbContextFixture.CreateInMemoryDbContext().SeedRecipes();
            IMapper mapper = AutoMapperFixture.CreateMapper();
            IRecipesService sut = new RecipesService(inMemoryDb, mapper);
            Recipe testRecipe = await inMemoryDb.Recipes.FirstAsync(r => !r.IsDeleted);

            //Act
            await sut.DeleteAsync(testRecipe.Id);

            //Assert
            Recipe deletedRecipe = await inMemoryDb.Recipes
                .FirstOrDefaultAsync(r => r.Id == testRecipe.Id);
            Recipe softDeletedRecipe = await inMemoryDb.Recipes
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(r => r.Id == testRecipe.Id);

            deletedRecipe.Should().BeNull();
            softDeletedRecipe.Should().NotBeNull();
        }
    }
}
