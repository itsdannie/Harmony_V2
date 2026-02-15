using Harmony.Common.Models.Contracts;

namespace Harmony.Recipes.Models
{
    public class Recipe: IDatedEntity, IDeletable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
