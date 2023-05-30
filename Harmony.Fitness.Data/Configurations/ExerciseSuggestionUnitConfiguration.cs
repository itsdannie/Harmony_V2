using Harmony.Fitness.Data.Seed;
using Harmony.Fitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Data.Configurations
{
    public class ExerciseSuggestionUnitConfiguration : IEntityTypeConfiguration<ExerciseSuggestionUnit>
    {
        public void Configure(EntityTypeBuilder<ExerciseSuggestionUnit> builder)
        {
            builder.Seed();
        }
    }
}
