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
using PennyApp.Data;

namespace PennyApp.Controllers
{
    public class TradesController : Controller
    {
        PennyAppEntities context = new PennyAppEntities();
        public ActionResult Index(List<IFormFile> files)
        {
            return View("Trades");
        }

        [HttpPost]
        public ActionResult OHLCcurve(List<HttpPostedFileBase> files)
        {
            Trade trade = new Trade();

            var result = new System.Text.StringBuilder();

            string filePath = string.Empty;
            string filename = string.Empty;
            //Read the contents of CSV file.
            string path = Server.MapPath("~/Uploads/");
            int count = 0;
            foreach (var file in files)
            {
                filename = file.FileName;
                string[] filename1 = filename.Split('.');
                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);
                string csvData = System.IO.File.ReadAllText(filePath);

                foreach (string row in csvData.Split('\n'))
                {
                    string[] data = row.Split(',');
                    if (data[0] != "")
                    {
                        if (data[0] == "\"Date\"")
                        {
                            continue;
                        }
                        else
                        {
                            trade.Ticker = filename1[0];
                            trade.Date = data[0];
                            trade.Time = data[1];
                            trade.Open = float.Parse(data[2]);
                            trade.High = float.Parse(data[3]);
                            trade.Low = float.Parse(data[4]);
                            trade.Close = float.Parse(data[5]);
                            trade.Vol = int.Parse(data[6]);
                            trade.OI = int.Parse(data[7]);
                            count++;

                            pennyApp1Entities1.Trades.Add(trade);
                            pennyApp1Entities1.SaveChanges();

                        }

                    }



                }


            }
            return Json(count + " rows inserted");
        }
    }
}