using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ProductImage
    {
        [Key]
        public string ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}