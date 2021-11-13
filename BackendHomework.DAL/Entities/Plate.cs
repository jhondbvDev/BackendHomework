using System;
using System.Collections.Generic;
using System.Text;

namespace BackendHomework.Core.Models
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
