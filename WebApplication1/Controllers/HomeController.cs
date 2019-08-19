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
        public ActionResult Index(string ticker)
        {
           int numberofrecord1 =  4000;
            if(ticker != null)
            { 
            string data = JsonConvert.SerializeObject(db.Trades.Where(z => z.Ticker == ticker).Select(x => new {
                x.Date,
                x.Close,
                x.Open,
                x.Low,
                x.High,
                x.Vol
            }).ToList().Take(numberofrecord1));
                ViewBag.data = data;
                ViewBag.tickername = ticker;
            }
            else
            {
                string data = JsonConvert.SerializeObject(db.Trades.Select(x => new {
                    x.Date,
                    x.Close,
                    x.Open,
                    x.Low,
                    x.High,
                    x.Vol
                }).ToList().Take(numberofrecord1));
                ViewBag.data = data;
            }
            
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

        public ActionResult Equitycurve(string ticker)
        {
            int numberofrecord = 400;
            if(ticker != null)
            { 
            string data = JsonConvert.SerializeObject(db.Trades.Where(z => z.Ticker == ticker).Select(x => new
            {
                x.Date,
                value = x.Close - x.Open,
            }).ToList().Take(numberofrecord)) ;
            ViewBag.data2 = data;
                ViewBag.tickername = ticker;
            }
            else
            {
                string data = JsonConvert.SerializeObject(db.Trades.Select(x => new
                {
                    x.Date,
                    value = x.Close - x.Open,
                }).ToList().Take(numberofrecord));
                ViewBag.data2 = data;
                ViewBag.tickername = ticker;
            }
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult OHLC(string ticker)
        {
            int numberofrecord1 = 4000;
            if (ticker != null)
            {
                string data = JsonConvert.SerializeObject(db.Trades.Where(z => z.Ticker == ticker).Select(x => new {
                    x.Date,
                    x.Close,
                    x.Open,
                    x.Low,
                    x.High,
                    x.Vol,
                    x.Moving_Avg,
                    x.Upper_BBand,
                    x.Lower_BBand
                }).ToList().Take(numberofrecord1));
                ViewBag.data = data;
                ViewBag.tickername = ticker;
            }
            else
            {
                string data = JsonConvert.SerializeObject(db.Trades.Select(x => new {
                    x.Date,
                    x.Close,
                    x.Open,
                    x.Low,
                    x.High,
                    x.Vol,
                    x.Moving_Avg,
                    x.Upper_BBand,
                    x.Lower_BBand
                }).ToList().Take(numberofrecord1));
                ViewBag.data = data;
            }

            return View();
        }
    }
}
 