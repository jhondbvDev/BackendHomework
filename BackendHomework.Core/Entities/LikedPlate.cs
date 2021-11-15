namespace BackendHomework.Core.Entities
{
    public class LikedPlate : BaseEntity
    {
        public virtual Plate Plate { get; set; }
        public virtual User User { get; set; }
    }
}
