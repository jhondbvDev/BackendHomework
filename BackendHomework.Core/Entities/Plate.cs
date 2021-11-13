using System.Collections.Generic;

namespace BackendHomework.Core.Entities
{
    public class Plate:BaseEntity
    {
        public Plate()
        {
            Ingredients = new HashSet<Ingredient>();
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

    }
}
