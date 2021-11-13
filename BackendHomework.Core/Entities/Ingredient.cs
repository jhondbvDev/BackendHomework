namespace BackendHomework.Core.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PlateId { get; set; }
        public Plate Plate { get; set; }
    }
}
