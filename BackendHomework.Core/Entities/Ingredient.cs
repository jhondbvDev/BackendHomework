namespace BackendHomework.Core.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public int PlateId { get; set; }
        public Plate Plate { get; set; }
    }
}
