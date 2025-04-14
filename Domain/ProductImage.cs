using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ProductImage
    {
        [Key]
        public string ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("ProductVariant")]
        public string ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}