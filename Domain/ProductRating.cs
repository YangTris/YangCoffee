using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductRating
    {
        [Key]
        public string ProductRatingId { get; set; }
        
        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
