using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Recipes.Models.Contracts
{
    public interface IDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
