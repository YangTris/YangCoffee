using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string BaseImageUrl { get; set; }
        public decimal BasePrice { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<ProductVariant> ProductVariants { get; set; }

    }
}