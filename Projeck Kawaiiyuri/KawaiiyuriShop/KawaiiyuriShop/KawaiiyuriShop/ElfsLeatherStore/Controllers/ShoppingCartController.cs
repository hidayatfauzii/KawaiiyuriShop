using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ElfsLeatherStore.Models;
namespace ElfsLeatherStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult AddToCart(int id)
        {
            var cart = (from c in db.ShoppingCarts
                        where c.ProductId == id
                        select c).SingleOrDefault();

            if (cart == null)
            {
                var newCart = new ShoppingCart
                {
                    Username = User.Identity.Name,
                    ProductId = id,
                    Qty = 1,
                    DateCreated = DateTime.Now
                };
                db.ShoppingCarts.Add(newCart);
            }
            else
            {
                cart.Qty = cart.Qty + 1;
            }

            db.SaveChanges();



            return RedirectToAction("ShowShoppingCart");
        }

        public ActionResult ShowShoppingCart()
        {
            var carts = from c in db.ShoppingCarts.Include("Product")
                        where c.Username == User.Identity.Name
                        select c;

            decimal total = 0;
            foreach (var item in carts)
            {
                total += (item.Qty * item.Product.Price);
            }
            ViewBag.Total = total;

            return View(carts);
        }

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
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

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Edit/5
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

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int id)
        {
            var cart = (from c in db.ShoppingCarts
                        where c.ShoppingCartId == id && c.Username == User.Identity.Name
                        select c).SingleOrDefault();

            if (cart != null)
            {
                if (cart.Qty > 1)
                {
                    cart.Qty -= 1;
                }
                else
                {
                    db.ShoppingCarts.Remove(cart);
                }
            }
            db.SaveChanges();

            return RedirectToAction("ShowShoppingCart");
        }

        // POST: ShoppingCart/Delete/5
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
