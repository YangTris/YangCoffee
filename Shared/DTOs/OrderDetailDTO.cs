using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OrderDetailDTO
    {
        public string OrderDetailId { get; set; }
        public string ProductVariantId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
        public string OrderId { get; set; }
    }
}
