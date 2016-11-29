using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElfsLeatherStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}