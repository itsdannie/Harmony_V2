using Harmony.Recipes.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Harmony.Recipes.Tests.Fixtures
{
    public static class DbContextFixture
    {
        public static RecipesDbContext CreateInMemoryDbContext()
        {
            DbContextOptionsBuilder<RecipesDbContext> builder = new DbContextOptionsBuilder<RecipesDbContext>();
            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            DbContextOptions<RecipesDbContext> dbContextOptions = builder.Options;
            RecipesDbContext inMemoryDbContext = new RecipesDbContext(dbContextOptions);
            inMemoryDbContext.Database.EnsureCreated();

            return inMemoryDbContext;
        }
    }
}
