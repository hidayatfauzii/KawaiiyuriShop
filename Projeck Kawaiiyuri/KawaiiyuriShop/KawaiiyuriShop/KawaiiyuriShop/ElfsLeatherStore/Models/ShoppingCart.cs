using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElfsLeatherStore.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }
    }
}