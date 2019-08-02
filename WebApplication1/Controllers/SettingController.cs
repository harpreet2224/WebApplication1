using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PennyApp.Controllers
{
    public class SettingController : Controller
    {
       
        public ActionResult option()
        {
            return View();
        }

        public ActionResult Feature()
        {
            return View();

        }

        public ActionResult Simulation()
        {
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }


    }
}