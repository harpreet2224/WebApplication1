using PennyApp.Data;
using PennyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PennyApp.Controllers
{
    public class SettingController : Controller
    {
        PennyAppEntities db = new PennyAppEntities();
        // GET: Setting
        public ActionResult option()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Feature()
        {
            var filter = db.Filters.ToList();
            List<ValueModel> values = new List<ValueModel>();
            FeatureViewModel model = new FeatureViewModel();
            foreach(var fil in filter)

            {
                values.Add(new ValueModel { id= fil.Id ,value=fil.Value});
            }
            
            model.Moving_Avg_Value = values;
            model.Volume_Filter_Value = values;
            model.Day_High_Value = values;
            model.Performance_Value = values;
            model.RSI_Value = values;
            model.Stochastics_Value = values;
            model.MACD_Hist_Value = values;
            model.Upper_BBand_Value = values;
            model.Lower_BBand_Value = values;
            return View(model);
        }


        [HttpPost]
        public ActionResult Feature(FeatureViewModel model)
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