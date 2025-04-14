using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain
{
    public class ProductVariant
    {
        [Key]
        public string ProductVariantId { get; set; }
        public Region Region { get; set; }
        public RoastType RoastType { get; set; }
        public Size Size { get; set; }
        public string Taste { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
        public List<ProductImage> ImageUrl { get; set; }
    }
}