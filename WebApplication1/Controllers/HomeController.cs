using Newtonsoft.Json;
using PennyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        PennyAppEntities db = new PennyAppEntities();
        public ActionResult Index()
        {
           int numberofrecord = 10;
            string data = JsonConvert.SerializeObject(db.Trades.Select(x => new {
                x.Date,
                x.Close,
                x.Open,
                x.Low,
                x.High
            }).ToList().Take(numberofrecord));
            ViewBag.data = data;
             //string jsonData = JsonConvert.SerializeObject(data);
             // ViewBag.data = jsonData; 
             return View();
        }

        public ActionResult graph()
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
    }
}
 