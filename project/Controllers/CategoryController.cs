using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.EF;

namespace project.Controllers
{
    public class CategoryController : Controller
    {
        private Context _db = new Context();

        // GET: Category
        public ActionResult Index()
        {
            return View(_db.Categories.AsEnumerable());
        }

        public ActionResult Display(int id)
        {
            ViewBag.ButtonTitle = "Edit";
            ViewBag.Action = "Edit";

            return View(_db.Categories.Find(id));
        }

        public ActionResult Edit(int id)
        {
            return View(_db.Categories.Find(id));
        }

        public ActionResult Update(Category category)
        {
            Category updatedOrNew;
            if (category.ID == 0)
            {
                updatedOrNew = new Category()
                {
                    Name = category.Name,
                    Description = category.Description
                };
                _db.Categories.Add(updatedOrNew);
            }
            else
            {
                updatedOrNew = _db.Categories.Find(category.ID);
                updatedOrNew.Name = category.Name;
                updatedOrNew.Description = category.Description;
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            return View("Edit", new Category());
        }
    }
}