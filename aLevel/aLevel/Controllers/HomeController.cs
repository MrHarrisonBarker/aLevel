﻿using System.Web.Mvc;
using LinqToTwitter;

namespace aLevel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!new SessionStateCredentialStore().HasAllCredentials())
                return RedirectToAction("Index", "OAuth");

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Status()
        {
            ViewBag.Message = "Your Status page.";

            return View();
        }

    }
}