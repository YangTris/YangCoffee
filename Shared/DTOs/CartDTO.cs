using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Shared.DTOs
{
    public class CartDTO
    {
        public string UserId { get; set; }
        public List<CartItemDTO> ? CartItems { get; set; }
    }
}
