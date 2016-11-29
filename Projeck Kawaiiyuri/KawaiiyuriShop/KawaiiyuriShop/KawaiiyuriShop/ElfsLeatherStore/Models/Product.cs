using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElfsLeatherStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Stock { get; set; }
        public string PicProduct { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }
}