using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElfsLeatherStore.BLL;
using ElfsLeatherStore.Models;

namespace ElfsLeatherStore.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private CategoryService service;

        public CategoryController()
        {
            service = new CategoryService();
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
        }

        // GET: Category
        public ActionResult Index()
        {
            var model = service.GetAll();

            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                service.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var model = service.GetById(id);

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                service.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var model = service.GetById(id);

            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                service.Delete(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }
    }
}
