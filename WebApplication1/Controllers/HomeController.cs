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
           int numberofrecord = 4000;
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

        public ActionResult Equitycurve()
        {
            int numberofrecord = 400;
            string data1 = JsonConvert.SerializeObject(db.Trades.Select(x => new
            {
                x.Date,
                value = x.Close - x.Open,
            }).ToList().Take(numberofrecord)) ;
            ViewBag.data2 = data1;

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult OHLC()
        {
            return View();
        }
    }
}
 