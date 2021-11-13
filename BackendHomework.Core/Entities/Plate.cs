using System.Collections.Generic;

namespace BackendHomework.Core.Entities
{
    public class Plate:BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        ICollection<Ingredient> Ingredients { get; set; }

    }
}
