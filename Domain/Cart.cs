using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<CartItem> CartItems { get; set; } 
    }
}
