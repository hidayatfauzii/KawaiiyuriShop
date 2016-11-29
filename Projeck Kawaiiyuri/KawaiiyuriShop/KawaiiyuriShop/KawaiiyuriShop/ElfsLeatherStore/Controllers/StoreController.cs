using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ElfsLeatherStore.Models;
using System.Net;
using System.Data.Entity;
namespace ElfsLeatherStore.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();
        // GET: Store
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();

            return View(categories);
        }

        public ActionResult Browse(int id)
        {
            var model = (from b in db.Categories.Include("Products")
                         where b.CategoryId == id
                         select b).SingleOrDefault();

            return View(model);
        }

        public ActionResult ShowSupplier()
        {
            var suppliers = db.Suppliers.ToList();

            return View(suppliers);
        }

        public ActionResult BrowseBySupplier(int id)
        {
            var model = (from a in db.Suppliers.Include("Products")
                         where a.SupplierId == id
                         select a).SingleOrDefault();
            return View(model);
        }

        public ActionResult SearchProductAND()
        {
            IEnumerable<Product> products = null;
            ViewBag.SupplierId = new SelectList(db.Suppliers.OrderBy(a => a.Name), "SupplierId",
                "Name");
            return View(products);
        }

        [HttpPost]
        public ActionResult SearchProductAND(int SupplierId, string ProductName, string Material)
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers.OrderBy(a => a.Name), "SupplierId",
               "Name", SupplierId);

            var products = from b in db.Products.Include("Supplier")
                           where b.SupplierId == SupplierId && b.ProductName.Contains(ProductName) &&
                           b.Material.Contains(Material)
                           select b;
            return View(products);
        }

        public ActionResult SearchProduct()
        {
            IEnumerable<Product> products = null;
            return View(products);
        }

        [HttpPost]
        public ActionResult SearchProduct(string keyword, string criteria)
        {
            IEnumerable<Product> products = null;
            switch (criteria)
            {
                case "ProductName":
                    products = from b in db.Products.Include("Supplier")
                            where b.ProductName.Contains(keyword)
                            select b;
                    break;
                case "Supplier":
                    products = from b in db.Products.Include("Supplier")
                            where b.Supplier.Name.Contains(keyword)
                            select b;
                    break;
                case "Material":
                    products = from b in db.Products.Include("Supplier")
                            where b.Material.Contains(keyword)
                            select b;
                    break;
            }
            return View(products);
        }

        // GET: Store/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers,
                "SupplierId", "Name", product.SupplierId);
            ViewBag.CategoryId = new SelectList(db.Categories,
                "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            string imgFolder = Server.MapPath("~/Images");
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    //hapus pic lama
                    string oldPic =
                        Path.Combine(imgFolder,
                        product.PicProduct != null ? product.PicProduct : "");
                    if (System.IO.File.Exists(oldPic))
                        System.IO.File.Delete(oldPic);

                    //tambah pic baru
                    string pic = Guid.NewGuid().ToString().Substring(0, 6) +
                        Path.GetFileName(file.FileName);
                    string path = Path.Combine(imgFolder, pic);
                    file.SaveAs(path);
                    product.PicProduct = pic;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", product.SupplierId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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
