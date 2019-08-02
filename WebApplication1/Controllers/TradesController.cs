using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static PennyApp.Models.Trades;
using System.IO.MemoryMappedFiles;
using Microsoft.AspNetCore.Http;
using PennyApp.Models;

namespace PennyApp.Controllers
{
    public class TradesController : Controller
    {
        public ActionResult Index(List<IFormFile> files)
        {
            return View("Trades");
        }

        [HttpPost]
        public ActionResult OHLCcurve(List<HttpPostedFileBase> files)
        {
           Trades trades = new Trades();
            var result = new System.Text.StringBuilder();

            string filePath = string.Empty;
            //Read the contents of CSV file.
            string path = Server.MapPath("~/Uploads/");
            foreach (var file in files)
            {
                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);
                string csvData = System.IO.File.ReadAllText(filePath);
             
                foreach (string row in csvData.Split('\n'))
                {
                    string[] data=row.Split(',');
                    if (data[0]== "\"Date\"")
                    {
                        continue;
                    }
                    else
                    {
                        trades.Ticker = filePath;
                        trades.Date = DateTime.Parse(data[0]);
                        trades.Time = Convert.ToDateTime(data[1]);
                        trades.Open = float.Parse(data[2]);
                        trades.High = float.Parse(data[3]);
                        trades.Low = float.Parse(data[4]);
                        trades.Close = float.Parse(data[5]);
                        trades.Vol = Double.Parse(data[6]);
                        trades.OI = int.Parse(data[7]);
                      
                    }
                }
               
            }
            return Json(result);
        }
    }
}