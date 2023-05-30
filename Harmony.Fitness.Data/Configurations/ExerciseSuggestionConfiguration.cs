using Harmony.Fitness.Data.Seed;
using Harmony.Fitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Harmony.Fitness.Data.Configurations
{
    public class ExerciseSuggestionConfiguration : IEntityTypeConfiguration<ExerciseSuggestion>
    {
        public void Configure(EntityTypeBuilder<ExerciseSuggestion> builder)
        {
            builder
                .HasMany(b => b.Units)
                .WithMany(b => b.ExerciseSuggestions)
                .UsingEntity<ExerciseSuggestionUnit>();

            builder.Seed();
        }
    }
}
