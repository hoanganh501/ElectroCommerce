namespace ElectroCommerce.Application.Request
{
    public class SearchProductRequest
    {
        public List<Guid>? BrandIds { get; set; }
        public List<Guid>? CategoryIds { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; } = "CreateAt";
        public bool IsDesc { get; set; }
    }
}
