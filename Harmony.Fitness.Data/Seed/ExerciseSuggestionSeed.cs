using Harmony.Fitness.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Data.Seed
{
    public static class ExerciseSuggestionSeed
    {
        public static void Seed(this EntityTypeBuilder<ExerciseSuggestion> builder)
        {
            builder.HasData(
                new ExerciseSuggestion { Id = 1, Name = "Plank"},
                new ExerciseSuggestion { Id = 2, Name = "Lat pull down"},
                new ExerciseSuggestion { Id = 3, Name = "Hip thrust"},
                new ExerciseSuggestion { Id = 4, Name = "Glute kickbacks"},
                new ExerciseSuggestion { Id = 5, Name = "Side leg lifts"},
                new ExerciseSuggestion { Id = 6, Name = "Lunges"},
                new ExerciseSuggestion { Id = 7, Name = "Reverse lunges"},
                new ExerciseSuggestion { Id = 8, Name = "Warm up"},
                new ExerciseSuggestion { Id = 9, Name = "Stretching" },
                new ExerciseSuggestion { Id = 10, Name = "Shoulder press" },
                new ExerciseSuggestion { Id = 11, Name = "Squats" },
                new ExerciseSuggestion { Id = 12, Name = "Bicep curls" },
                new ExerciseSuggestion { Id = 13, Name = "Hip" },
                new ExerciseSuggestion { Id = 14, Name = "Plank hip dips" },
                new ExerciseSuggestion { Id = 15, Name = "Treadmil" },
                new ExerciseSuggestion { Id = 16, Name = "Lat raise" },
                new ExerciseSuggestion { Id = 17, Name = "DB chest press" },
                new ExerciseSuggestion { Id = 18, Name = "Knee push up" },
                new ExerciseSuggestion { Id = 19, Name = "Dead bugs" },
                new ExerciseSuggestion { Id = 20, Name = "Steps" },
                new ExerciseSuggestion { Id = 21, Name = "Russian Twist" },
                new ExerciseSuggestion { Id = 22, Name = "Single leg deadlift" }
                );
        }
    }
}
