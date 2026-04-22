using Domain.Enum;

namespace Domain.Entities
{
    public class Order: BaseEntity
    {
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Guid? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public OrderStatus Staus { get; set; }
        public OrderType Type { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
