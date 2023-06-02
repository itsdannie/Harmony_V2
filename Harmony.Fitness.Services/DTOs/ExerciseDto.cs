using Harmony.Common.Mapping;
using Harmony.Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Services.DTOs
{
    public class ExerciseDto: IMapFrom<Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public ICollection<ExercisePropertyDto> Properties { get; set; }
    }
}
