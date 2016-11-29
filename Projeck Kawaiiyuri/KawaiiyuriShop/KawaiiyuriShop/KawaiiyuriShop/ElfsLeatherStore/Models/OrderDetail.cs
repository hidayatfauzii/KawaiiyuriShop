using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElfsLeatherStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }

        public virtual Order Order { get; set; }
        public virtual Category category { get; set; }
    }
}