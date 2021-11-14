namespace BackendHomework.Core.Entities
{
    public class Plate:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
