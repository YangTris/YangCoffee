namespace Shared.DTOs
{
    public class ProductQuery
    {
        public string? SearchString { get; set; }
        public string[]? CategoryId { get; set; }
        public string? SortBy { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 6;
    }
}
