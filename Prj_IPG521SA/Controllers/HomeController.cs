using Prj_IPG521SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_IPG521SA.Controllers
{
    public class HomeController : Controller
    {
        private IPG521SAEntities db = new IPG521SAEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Papers()
        {
            return View(db.Papers.ToList());
        }

        public ActionResult News()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}