using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.EF;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private Context _db = new Context();

        // GET: Home
        public ActionResult Index()
        {
            return View(Helpers.getPosts());
        }

        public ActionResult Display(int id)
        {
            return RedirectToAction("Display", "Node", new { id});
        }
    }
}