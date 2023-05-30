using Harmony.Common.Models.Contracts;
using Harmony.Fitness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Harmony.Fitness.Data
{
    public class FitnessDbContext : DbContext
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(FitnessDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        private IHttpContextAccessor _httpContextAccessor;

        public FitnessDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = httpContextAccessor;
            this.ChangeTracker.StateChanged += this.ChangeTracker_StateChanged;
            this.ChangeTracker.Tracked += this.ChangeTracker_Tracked;
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseProperty> ExerciseDetails { get; set; }
        public DbSet<ExerciseSuggestion> ExerciseSuggestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Finds classes that implement 'IEntityTypeConfiguration<>' in the assembly and applies them.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FitnessDbContext).Assembly);

            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletable).IsAssignableFrom(et.ClrType));

            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { modelBuilder });
            }
        }

        private void ChangeTracker_Tracked(object? sender, EntityTrackedEventArgs e)
        {
            if (!e.Entry.IsKeySet && e.Entry.State == EntityState.Added && e.Entry.Entity is IDatedEntity entity)
            {
                entity.CreatedOn = DateTimeOffset.UtcNow;
                entity.UpdatedOn = DateTimeOffset.UtcNow;
            }


        }

        private void ChangeTracker_StateChanged(object? sender, EntityStateChangedEventArgs e)
        {
            if ((e.NewState == EntityState.Added || e.NewState == EntityState.Modified) && e.Entry.Entity is IDatedEntity entity)
            {
                if (e.NewState == EntityState.Added)
                {
                    entity.CreatedOn = DateTimeOffset.UtcNow;
                }
                entity.UpdatedOn = DateTimeOffset.UtcNow;
            }
            if (e.Entry.State == EntityState.Deleted && e.Entry.Entity is IDeletable deletableEntity)
            {
                e.Entry.State = EntityState.Modified;
                deletableEntity.IsDeleted = true;
                deletableEntity.DeletedOn = DateTime.UtcNow;
            }

        }
        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
       where T : class, IDeletable
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}