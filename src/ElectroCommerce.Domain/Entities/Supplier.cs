namespace Domain.Entities
{
    public class Supplier: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
