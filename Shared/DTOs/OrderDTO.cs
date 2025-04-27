using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OrderDTO
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string  PhoneNumber{ get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
