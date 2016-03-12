using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSample.ViewModels
{
    public class ProductIndexViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 9999)]
        public Nullable<decimal> Price { get; set; }

        [Required]
        [Range(0, 9999)]
        public Nullable<decimal> Stock { get; set; }
    }
}