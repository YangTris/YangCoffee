using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enum;
using Domain;

namespace Application.DTOs
{
    public class ProductVariantDTO
    {
        public string ProductVariantId { get; set; }
        public Region Region { get; set; }
        public RoastType RoastType { get; set; }
        public Size Size { get; set; }
        public string Taste { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
    }
}
