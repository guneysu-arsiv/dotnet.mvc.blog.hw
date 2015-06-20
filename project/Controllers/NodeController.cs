using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class NodeController : Controller
    {
        // GET: Node
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}