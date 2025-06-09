namespace Shared.DTOs
{
    public class AddProductDTO
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public string CategoryId { get; set; }
        public string productVariantId { get; set; }
        public int quantity { get; set; } = 1;
        public List<ProductImageDTO>? ProductImages { get; set; }
        public List<ProductVariantDTO>? ProductVariants { get; set; }
        public List<ProductRatingDTO>? ProductRatings { get; set; }
        public double? AverageRating { get; set; }
    }
}
