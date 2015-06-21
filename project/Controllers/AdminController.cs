using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.EF;

namespace project.Controllers
{
    public class AdminController : Controller
    {
        private Context _db = new Context();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}