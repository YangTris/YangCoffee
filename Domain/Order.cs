using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}