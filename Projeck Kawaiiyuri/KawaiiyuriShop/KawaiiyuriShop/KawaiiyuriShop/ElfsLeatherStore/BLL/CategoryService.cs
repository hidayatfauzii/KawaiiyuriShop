using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElfsLeatherStore.Models;

namespace ElfsLeatherStore.BLL
{
    public class CategoryService : IDisposable, IRepository<Category>
    {
        private StoreContext db;

        public CategoryService()
        {
            db = new StoreContext();
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories.OrderBy(c => c.Name).Select(c => c);
        }

        public Category GetById(int id)
        {
            var category = (from c in db.Categories
                            where c.CategoryId == id
                            select c).SingleOrDefault();

            return category;
        }

        public void Add(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Update(Category entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Category entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}