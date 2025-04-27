using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enum;

namespace Domain
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}