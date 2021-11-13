using System.Collections.Generic;

namespace BackendHomework.Core.Entities
{
    public class Plate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        ICollection<Ingredient> Ingredients { get; set; }

    }
}
