using Harmony.Fitness.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Data.Seed
{
    public static class UnitSeed
    {
        public static void Seed(this EntityTypeBuilder<Unit> builder)
        {
            builder.HasData(
                new Unit { Id = 1, Name = "sets"},
                new Unit { Id = 2, Name = "reps"},
                new Unit { Id = 3, Name = "h"},
                new Unit { Id = 4, Name = "min"},
                new Unit { Id = 5, Name = "sec"},
                new Unit { Id = 6, Name = "kg"},
                new Unit { Id = 7, Name = "lb"},
                new Unit { Id = 8, Name = "speed"},
                new Unit { Id = 9, Name = "incline"},
                new Unit { Id = 10, Name = "steps"}
                );
        }
    }
}
