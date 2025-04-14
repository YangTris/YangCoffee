using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetail
    {
        [Key]
        public string OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("ProductVariant")]
        public string ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
