using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class ProductQuery
    {
        public string[]? CategoryId { get; set; }
        public string? SortBy { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 6;
    }
}
