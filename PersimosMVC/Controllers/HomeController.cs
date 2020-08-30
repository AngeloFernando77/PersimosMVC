using PersimosMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeUser(idOperacion: 2)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}