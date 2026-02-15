using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Harmony.Data
{
    public class HarmonyDbContext: DbContext
    {
        private const string DEFAULT_SCHEMA = "harmony";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}