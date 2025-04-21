using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Shared.DTOs
{
    public class ProductImageDTO
    {
        public string ProductImageId { get; set; }
        public string ProductId { get; set; }
        public string ImageUrl { get; set; }
    }
}
