using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ElfsLeatherStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Nama Kategori")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}