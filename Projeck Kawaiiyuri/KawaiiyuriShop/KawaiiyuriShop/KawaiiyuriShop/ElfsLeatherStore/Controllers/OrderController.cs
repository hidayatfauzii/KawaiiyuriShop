using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ElfsLeatherStore.Models;
namespace ElfsLeatherStore.Controllers
{
    public class OrderController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var newOrder = new Order
            {
                FullName = order.FullName,
                Username = User.Identity.Name,
                Address = order.Address,
                Phone = order.Phone,
                OrderDate = DateTime.Now
            };

            db.Orders.Add(newOrder);
            db.SaveChanges();

            var carts = from c in db.ShoppingCarts
                        where c.Username == User.Identity.Name
                        select c;

            foreach (var item in carts)
            {
                var newOrderDetail = new OrderDetail
                {
                    OrderId = newOrder.OrderId,
                    BookId = item.ProductId,
                    Qty = item.Qty
                };
                db.OrderDetails.Add(newOrderDetail);
                db.ShoppingCarts.Remove(item);
            }

            db.SaveChanges();

            return RedirectToAction("Completed");
        }

        public ActionResult Completed()
        {
            return View();
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
