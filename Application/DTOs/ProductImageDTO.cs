﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.DTOs
{
    public class ProductImageDTO
    {
        public string ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductVariantId { get; set; }
    }
}
