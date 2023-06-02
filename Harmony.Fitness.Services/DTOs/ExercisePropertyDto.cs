using Harmony.Common.Mapping;
using Harmony.Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Services.DTOs
{
    public class ExercisePropertyDto: IMapFrom<ExerciseProperty>
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public int Value { get; set; }
    }
}
