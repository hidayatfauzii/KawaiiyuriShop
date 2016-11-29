using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;
using ElfsLeatherStore.Models;

namespace ElfsLeatherStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private StoreContext db = new StoreContext();
        // GET: Product
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var products = db.Products.Include(b => b.Supplier).Include(b => b.Category)
                .OrderBy(b => b.ProductName);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
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
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId =
                new SelectList(db.Suppliers.OrderBy(a => a.Name), "SupplierId", "Name");
            ViewBag.CategoryId =
                new SelectList(db.Categories.OrderBy(c => c.Name), "CategoryId", "Name");

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //upload file
                if (file != null)
                {
                    string pic = Guid.NewGuid().ToString().Substring(0, 6) +
                        Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), pic);
                    file.SaveAs(path);

                    product.PicProduct = pic;
                    db.Products.Add(product);
                    db.SaveChanges();

                    ViewBag.Success = "Data produk dengan nama " + product.ProductName +
                        " sudah berhasil ditambahkan";
                }
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "Name", product.SupplierId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
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

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            string oldFilePath = Path.Combine(Server.MapPath("~/Images"),
                   product.PicProduct != null ? product.PicProduct : "");
            if (System.IO.File.Exists(oldFilePath))
                System.IO.File.Delete(oldFilePath);

            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
