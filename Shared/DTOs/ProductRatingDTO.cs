using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Shared.DTOs
{
    public class ProductRatingDTO
    {
        public string ProductRatingId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
