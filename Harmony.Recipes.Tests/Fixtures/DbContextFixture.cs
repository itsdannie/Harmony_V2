using Harmony.Recipes.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Recipes.Tests.Fixtures
{
    public static class DbContextFixture
    {
        public static RecipesDbContext CreateInMemoryDbContext(IHttpContextAccessor userContext = null)
        {
            DbContextOptionsBuilder<RecipesDbContext> builder = new DbContextOptionsBuilder<RecipesDbContext>();
            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            DbContextOptions<RecipesDbContext> dbContextOptions = builder.Options;
            RecipesDbContext inMemoryDbContext = new RecipesDbContext(dbContextOptions, userContext);
            inMemoryDbContext.Database.EnsureCreated();

            return inMemoryDbContext;
        }
    }
}
