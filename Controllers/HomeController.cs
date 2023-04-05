using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5120_Quality_Education_in_Australia_Iterastion_01.Models;

namespace FIT5120_Quality_Education_in_Australia_Iteration_01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Religions () 
        { 
            return View(); 
        }

        public ActionResult PasswordProtection()
        {
            return View(new WebsiteProtectionVM());
        }

        [HttpPost]
        public ActionResult PasswordProtection([Bind(Include = "password")] WebsiteProtectionVM websiteProtectionVm)
        {
            if (websiteProtectionVm.password == "Iteration01")
            {
                return RedirectToAction("Index", "Home");
            }
            else if (websiteProtectionVm.password != "Iteration01")
            {
                ViewBag.ErrMsg = "Password incorrect, please check and enter again!";
                return View(websiteProtectionVm);
            }

            return null;
        }
    }
}