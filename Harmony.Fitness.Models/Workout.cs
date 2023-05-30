using Harmony.Common.Models.Contracts;
using Harmony.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Fitness.Models
{
    public class Workout : IDeletable, IDatedEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Weekday Weekday { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
        public bool IsDeleted { get; set ; }
        public DateTimeOffset? DeletedOn { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
