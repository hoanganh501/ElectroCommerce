namespace Domain.Entities
{
    public class ProductSpecification: BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
    