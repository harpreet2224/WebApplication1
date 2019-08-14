using PennyApp.Data;
using PennyApp.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PennyApp.Controllers
{
    public class SettingController : Controller
    {
        PennyAppEntities db = new PennyAppEntities();
        

        [HttpGet]
        public ActionResult option()
        {
            var filters = db.Filters.Where(x=>x.Category=="Filter").Select
                (x=>new { id = x.Id, value = x.Value }).ToList();
            var stop_Opt = db.Filters.Where(x => x.Category == "stop").Select
                (x => new { id = x.Id, value = x.Value }).ToList();
            if (filters != null && stop_Opt != null)
            {
                ViewData["stop_option_drop"] = stop_Opt;
                ViewData["filters"] = filters;
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult option(StopOptionViewModel model)
        //{

        //}
        
        [HttpGet]
        public ActionResult Feature()
        {
           
            var filter = db.Filters.ToList();
            var feature = db.Features.FirstOrDefault();
            FeatureViewModel model = new FeatureViewModel();
            List<ValueModel> filters = new List<ValueModel>();
            List<ValueModel> percentage = new List<ValueModel>();
            List<ValueModel> option = new List<ValueModel>();
            List<ValueModel> reduceBy = new List<ValueModel>();
            List<ValueModel> abovebelow = new List<ValueModel>();
            List<ValueModel> performance = new List<ValueModel>();

        
            
            foreach (var fil in filter)
            {
                if(fil.Category == "Filter")
                { 
                filters.Add(new ValueModel { id = fil.Id, value = fil.Value });
                }
                if(fil.Category == "Percentage")
                {
                    percentage.Add(new ValueModel { id = fil.Id, value = fil.Value });
                }
                if (fil.Category == "Option")
                {
                    option.Add(new ValueModel { id = fil.Id, value = fil.Value });
                }
                if (fil.Category == "ReduceBy")
                {
                    reduceBy.Add(new ValueModel { id = fil.Id, value = fil.Value });
                }
                if (fil.Category == "AboveBelow")
                {
                    abovebelow.Add(new ValueModel { id = fil.Id, value = fil.Value });
                }
                if (fil.Category == "Performance")
                {
                    performance.Add(new ValueModel { id = fil.Id, value = fil.Value });
                }
                
            }
            if(feature != null)
            {
                model.Consecutive_High = feature.Consecutive_High == 1 ? true : false;
                model.Consecutive_High_Filter = feature.Consecutive_High_Filter;
                model.Consecutive_Low = feature.Consecutive_Low == 1? true : false;
                model.Consecutive_Low_Filter = feature.Consecutive_Low_Filter;
                model.Volume = feature.Volume==1?true:false;
                model.Volume_Filter = feature.Volume_Filter;
                //model.Day_High = feature.Day_High == 1 ? true : false;
                //model.Day_High_Filter = feature.Consecutive_High_Filter;
                model.Performance = feature.Performance == 1 ? true : false;
                model.Performance_Filter = feature.Performance_Filter;
                model.RSI = feature.RSI == 1? true:false;
                model.RSI_Filter = feature.RSI_Filter;
                model.RSIfrom = feature.RSIfrom;
                model.RSIto = feature.RSIto;
                model.Stochastics = feature.Stochastics ==1? true:false;
                model.Stochastics_Filter = feature.Stochastics_Filter;
                model.StochasticsFrom = feature.StochasticsTo;
                model.MACD_Hist = feature.MACD_Hist ==1? true:false;
                model.MACD_Hist_Filter = feature.MACD_Hist_Filter;
                model.MACD_HistFrom = feature.MACD_HistFrom;
                model.MACD_HistTo = feature.MACD_HistTo;
                model.Moving_Avg = feature.Moving_Avg == 1 ? true : false;
                model.Moving_Avg_Filter = feature.Moving_Avg_Filter;
                model.Moving_Avg_Day1 = feature.Moving_Avg_Day_1;
                model.Moving_Avg_Day2 = feature.Moving_Avg_Day_2;
                model.Volume_Price_Value = feature.Volume_value;
                model.Performance_Price_Value = feature.Performance_value;
                model.Upper_BBand = feature.Upper_BBand == 1 ? true : false;
                model.Upper_BBand_Filter = feature.Upper_BBand_Filter;
                model.Upper_BBandFrom = feature.Upper_BBandFrom;
                model.Upper_BBandTo = feature.Upper_BBandTo;
                model.Lower_BBand = feature.Lower_BBand == 1 ? true : false;
                model.Lower_BBand_Filter = feature.Lower_BBand_Filter;
                model.Lower_BBandFrom = feature.Lower_BBandFrom;
                model.Lower_BBandTo = feature.Lower_BBandTo;
                model.Moving_Avg_Value = abovebelow;
                model.Volume_Filter_Value = filters;
              //  model.Day_High_Value = abovebelow;
                model.Performance_Value = performance;
                model.RSI_Value = filters;
                model.Stochastics_Value = filters;
                model.MACD_Hist_Value = filters;
                model.Upper_BBand_Value = abovebelow;
                model.Lower_BBand_Value = abovebelow;

            }
            else
            {
                model.Moving_Avg_Value = abovebelow;
                model.Volume_Filter_Value = filters;
             //   model.Day_High_Value = abovebelow;
                model.Performance_Value = performance;
                model.RSI_Value = filters;
                model.Stochastics_Value = filters;
                model.MACD_Hist_Value = filters;
                model.Upper_BBand_Value = abovebelow;
                model.Lower_BBand_Value = abovebelow;
            }
           
            return View(model);
        }

        public Object UpdateMov_avg(double sum,int j)
        {
            var k = j+1;
            var record = db.Trades.Where(x => x.Id == k).FirstOrDefault();
            if(record != null)
            {
                //record.Moving_Avg = Convert.ToDouble(sum);
                var rec = db.Trades.Where(y => y.Id == k ).FirstOrDefault();
                rec.Moving_Avg = sum;
                db.SaveChanges();

            }
            return (record);
        } 
        [HttpPost]
        public ActionResult Feature(FeatureViewModel model)
        {
            var clolist = db.Trades.Select(x => x.Close).ToArray();
            var rsi = db.Features.Select(x => x.RSIfrom).ToArray();
            var stock = db.Features.Select(x => x.StochasticsFrom).ToArray();
            var MACH = db.Features.Select(x => x.MACD_HistFrom).ToArray();
            var upper_band = db.Features.Select(x => x.Upper_BBandFrom).ToArray();
            var lower_band = db.Features.Select(x => x.Lower_BBandFrom).ToArray();
            
            var list = db.Features.Select(x => x.Moving_Avg_Day_1).FirstOrDefault();
            int j = (int)list;
            var record = db.Trades.Where(x => x.Id == j).FirstOrDefault();
            Trade trade = new Trade();

            decimal sum = 0;

            for (var i = 0; i < j; i++)
            {
                sum = 0;
                for (var k = i; k < j; k++)
                {
                    sum = sum + Convert.ToDecimal(clolist[k]);
                }

                //sum = sum + Convert.ToDecimal(clolist[i]);
                sum = sum / j;
                for(int l = 0; l < j; l++)
                {
                     var upper = Convert.ToDecimal(clolist[l]) - sum;
                }

                trade.Moving_Avg = Convert.ToDouble(sum);
                record.Moving_Avg = Convert.ToDouble(sum);
                UpdateMov_avg(Convert.ToDouble(sum), j+i);

            }

            sum = (sum / j);
            Console.WriteLine(clolist[0]);


            var data = db.Features.FirstOrDefault();
            var filter = db.Filters.ToList();
            List<ValueModel> values = new List<ValueModel>();

            


            foreach (var fil in filter)
            {
                values.Add(new ValueModel { id = fil.Id, value = fil.Value });

            }
            model.Moving_Avg_Value = values;
            model.Volume_Filter_Value = values;
           // model.Day_High_Value = values;
            model.Performance_Value = values;
            model.RSI_Value = values;
            model.Stochastics_Value = values;
            model.MACD_Hist_Value = values;
            model.Upper_BBand_Value = values;
            model.Lower_BBand_Value = values;
            if (data != null)
            {
                data.Moving_Avg = model.Moving_Avg == true ? 1 : 0;
                data.Moving_Avg_Filter = model.Moving_Avg_Filter;
                data.Moving_Avg_Day_1 = model.Moving_Avg_Day1;
                data.Moving_Avg_Day_2 = model.Moving_Avg_Day2;
                data.Volume_value = model.Volume_Price_Value;
                data.Performance_value = model.Performance_Price_Value;
                data.Volume = model.Volume == true ? 1 : 0;
                data.Volume_Filter = model.Volume_Filter;
              //  data.Day_High = model.Day_High == true ? 1 : 0;
                data.Performance = model.Performance == true ? 1 : 0;
                data.Performance_Filter = model.Performance_Filter;
                data.Consecutive_High = model.Consecutive_High == true ? 1 : 0;
             //   data.Day_High_Filter = model.Day_High_Filter;
                data.Consecutive_Low = model.Consecutive_Low == true ? 1 : 0;
                data.Consecutive_Low_Filter = model.Consecutive_Low_Filter;
                data.RSI = model.RSI == true ? 1 : 0;
                data.RSI_Filter = model.RSI_Filter;
                data.RSIfrom = model.RSIfrom;
                data.RSIto = model.RSIto;
                data.Stochastics = model.Stochastics == true ? 1 : 0;
                data.Stochastics_Filter = model.Stochastics_Filter;
                data.StochasticsFrom = model.StochasticsFrom;
                data.StochasticsTo = model.StochasticsTo;
                data.MACD_Hist = model.MACD_Hist == true ? 1 : 0;
                data.MACD_Hist_Filter = model.MACD_Hist_Filter;
                data.MACD_HistFrom = model.MACD_HistFrom;
                data.MACD_HistFrom = model.MACD_HistFrom;
                data.MACD_HistTo = model.MACD_HistTo;
                data.Upper_BBand = model.Upper_BBand == true ? 1 : 0;
                data.Upper_BBand_Filter = model.Upper_BBand_Filter;
                data.Upper_BBandFrom = model.Upper_BBandFrom;
                data.Upper_BBandTo = model.Upper_BBandTo;
                data.Lower_BBand = model.Lower_BBand == true ? 1 : 0;
                data.Lower_BBand_Filter = model.Lower_BBand_Filter;
                data.Lower_BBandFrom = model.Lower_BBandFrom;
                data.Lower_BBandTo = model.Lower_BBandTo;
                db.SaveChanges();
                return View(model);
            }
            else
            { 
            Feature feature = new Feature();
            feature.Moving_Avg = model.Moving_Avg == true ? 1 : 0;
            feature.Moving_Avg_Filter = model.Moving_Avg_Filter;
            feature.Moving_Avg_Day_1 = model.Moving_Avg_Day1;
            feature.Moving_Avg_Day_2 = model.Moving_Avg_Day2;
            feature.Volume = model.Volume == true ? 1 : 0;
            feature.Volume_Filter = model.Volume_Filter;
         //   feature.Day_High = model.Day_High == true ? 1 : 0;
            feature.Performance = model.Performance == true ? 1 : 0;
            feature.Performance_Filter = model.Performance_Filter;
            feature.Consecutive_High = model.Consecutive_High == true ? 1 : 0;
         //   feature.Day_High_Filter = model.Day_High_Filter;
            feature.Consecutive_Low = model.Consecutive_Low == true ? 1 : 0;
            feature.Consecutive_Low_Filter = model.Consecutive_Low_Filter;
            feature.RSI = model.RSI == true ? 1 : 0;
            feature.RSI_Filter = model.RSI_Filter;
            feature.RSIfrom = model.RSIfrom;
            feature.RSIto = model.RSIto;
            feature.Stochastics = model.Stochastics == true ? 1 : 0;
            feature.Stochastics_Filter = model.Stochastics_Filter;
            feature.StochasticsFrom = model.StochasticsFrom;
            feature.StochasticsTo = model.StochasticsTo;
            feature.MACD_Hist = model.MACD_Hist == true ? 1 : 0;
            feature.MACD_Hist_Filter = model.MACD_Hist_Filter;
            feature.MACD_HistFrom = model.MACD_HistFrom;
            feature.MACD_HistFrom = model.MACD_HistFrom;
            feature.MACD_HistTo = model.MACD_HistTo;
            feature.Upper_BBand = model.Upper_BBand == true ? 1 : 0;
            feature.Upper_BBand_Filter = model.Upper_BBand_Filter;
            feature.Upper_BBandFrom = model.Upper_BBandFrom;
            feature.Upper_BBandTo = model.Upper_BBandTo;
            feature.Lower_BBand = model.Lower_BBand == true ? 1 : 0;
            feature.Lower_BBand_Filter = model.Lower_BBand_Filter;
            feature.Lower_BBandFrom = model.Lower_BBandFrom;
            feature.Lower_BBandTo = model.Lower_BBandTo;
            db.Features.Add(feature);
            db.SaveChanges();
            return View(model);
            }
        }


        [HttpGet]
        public ActionResult Simulation()
        {
            var filters = db.Filters.Where(x => x.Category == "Filter").Select
               (x => new { id = x.Id, value = x.Value }).ToList();
            var stop_Opt = db.Filters.Where(x => x.Category == "stop").Select
                (x => new { id = x.Id, value = x.Value }).ToList();
            if (filters != null && stop_Opt != null)
            {
                ViewData["stop_option_drop"] = stop_Opt;
                ViewData["filters"] = filters;
            }
            ViewBag.RepoPeriod = DrpReportPeroid();
            ViewBag.ReduceByVal = DrpReduceBy();
            return View();
        }

        [HttpPost]
        public ActionResult Simulation(Simulation_StopOptions simulationViewModel)
        {
            var target = simulationViewModel.Target.Split(',');
            var ticker = db.Trades.Where(x => x.Ticker == simulationViewModel.Stratgy).ToList();

            try
            {
                db.Simulations.Add(new Simulation {
                    Stratgy = simulationViewModel .Stratgy,
                    DollerPerPosition= simulationViewModel.DollerPerPosition,
                    Target=Convert.ToInt32(target[0]),
                    ReduceBy= simulationViewModel.ReduceBy,
                    UseAccountDollers= Convert.ToInt32(simulationViewModel.UseAccountDollers)

                    
                });

                switch (target.Count())
                {
                    case 1:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            break;
                        }
                    case 2:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            break;
                        }
                    case 3:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));

                            break;
                        }
                    case 4:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));
                            ticker.Select(x => x.Ext4 = Convert.ToInt32(target[3]));
                            break;
                        }
                    case 5:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));
                            ticker.Select(x => x.Ext4 = Convert.ToInt32(target[3]));
                            ticker.Select(x => x.Ext5 = Convert.ToInt32(target[4]));

                            break;
                        }
                    case 6:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));
                            ticker.Select(x => x.Ext4 = Convert.ToInt32(target[3]));
                            ticker.Select(x => x.Ext5 = Convert.ToInt32(target[4]));
                            ticker.Select(x => x.Ext6 = Convert.ToInt32(target[5]));
                            break;
                        }
                    case 7:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));
                            ticker.Select(x => x.Ext4 = Convert.ToInt32(target[3]));
                            ticker.Select(x => x.Ext5 = Convert.ToInt32(target[4]));
                            ticker.Select(x => x.Ext6 = Convert.ToInt32(target[5]));
                            ticker.Select(x => x.Ext7 = Convert.ToInt32(target[6]));
                            break;
                        }
                    case 8:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));
                            ticker.Select(x => x.Ext4 = Convert.ToInt32(target[3]));
                            ticker.Select(x => x.Ext5 = Convert.ToInt32(target[4]));
                            ticker.Select(x => x.Ext6 = Convert.ToInt32(target[5]));
                            ticker.Select(x => x.Ext7 = Convert.ToInt32(target[6]));
                            ticker.Select(x => x.Ext8 = Convert.ToInt32(target[7]));
                            break;
                        }
                    case 9:
                        {
                            ticker.Select(x => x.Ext1 = Convert.ToInt32(target[0]));
                            ticker.Select(x => x.Ext2 = Convert.ToInt32(target[1]));
                            ticker.Select(x => x.Ext3 = Convert.ToInt32(target[2]));
                            ticker.Select(x => x.Ext4 = Convert.ToInt32(target[3]));
                            ticker.Select(x => x.Ext5 = Convert.ToInt32(target[4]));
                            ticker.Select(x => x.Ext6 = Convert.ToInt32(target[5]));
                            ticker.Select(x => x.Ext7 = Convert.ToInt32(target[6]));
                            ticker.Select(x => x.Ext8 = Convert.ToInt32(target[7]));
                            ticker.Select(x => x.Ext9 = Convert.ToInt32(target[8]));
                            break;
                        }
                    default:
                        break;
                };
                db.SaveChanges();
                ViewBag.Message = true;
            }
            catch (Exception)
            {
                ViewBag.Message = false;
                throw;
            }

            var filters = db.Filters.Where(x => x.Category == "Filter").Select
               (x => new { id = x.Id, value = x.Value }).ToList();
            var stop_Opt = db.Filters.Where(x => x.Category == "stop").Select
                (x => new { id = x.Id, value = x.Value }).ToList();
            if (filters != null && stop_Opt != null)
            {
                ViewData["stop_option_drop"] = stop_Opt;
                ViewData["filters"] = filters;
            }
            ViewBag.RepoPeriod = DrpReportPeroid();
            ViewBag.ReduceByVal = DrpReduceBy();
            ModelState.Clear();
            return View();
        }
        public List<SelectListItem> DrpReduceBy()
        {
            var valList = db.Filters.Where(z => z.Category == "ReduceBy").Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Value.ToString()
            }).ToList();
            return valList;
        }
        public List<SelectListItem> DrpReportPeroid()
        {
            var Report_period = db.Filters.Where(z => z.Category == "Performance").Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Value
            }).ToList();
            return Report_period;
        }
        public ActionResult Result()
        {
            //var list = (from Trades in db.Trades select Trades).
            //   GroupBy(x => x.Ticker)
            //   .Select(x =>
            //  x.OrderBy(y => y.Date).FirstOrDefault()).ToList();

            //return View(list);


            List<TradeViewModel> tradeViewList = new List<TradeViewModel>();
              TradeViewModel trades = new TradeViewModel();
             var list = (from Trades in db.Trades select Trades).
              GroupBy(x => x.Ticker)
              .Select(x =>
              x.OrderBy(y => y.Date).FirstOrDefault()).ToList();

            return View(list);

        //    var features = db.Features.FirstOrDefault();
        //    int day1 = features.Moving_Avg_Day_1 ?? default(int);
        //    int day2 = features.Moving_Avg_Day_2 ?? default(int);
        //    var tradeList = db.Trades.ToList();
        //    var getalltrades = tradeList.Select(z => z.Ticker).ToList();
        //    var getall = (from Trades in db.Trades select Trades).
        //      GroupBy(x => x.Ticker)
        //       .Select(x =>
        //      x.OrderBy(y => y.Date).FirstOrDefault()).ToList();

        //    var simulation = db.Simulations.FirstOrDefault();
        //    var movingAverage1 = tradeList.Select(z => z.Close).Take(day1).Average();
        //    var movingAverage2 = tradeList.Select(z => z.Close).Take(day2).Average();

        //    foreach (var trade in getalltrades)
        //    {
        //        var gettradebyticker = tradeList.Where(z => z.Ticker == trade && z.Close > movingAverage1 && z.Close > movingAverage2).ToList();
        //        var count = gettradebyticker.Count();
        //        var firstValue = gettradebyticker.Select(z => z.Close).FirstOrDefault();
        //        foreach (var ticker in gettradebyticker)
        //        {
        //            var priceNow = gettradebyticker.Select(z => z.Close).LastOrDefault();
        //            if (ticker.Close > firstValue)
        //            {
        //                tradeViewList.Add(new TradeViewModel
        //                {
        //                    Date = Convert.ToDateTime(ticker.Date),
        //                    Ticker = ticker.Ticker,
        //                    Amount = ticker.Amout,
        //                    Entrypx = simulation.DollerPerPosition,
        //                    Exit1 = ticker.Ext1,
        //                    PriceNow = priceNow,
        //                    Realized = Convert.ToInt32(ticker.Realized),
        //                    Unrealized = Convert.ToInt32(ticker.unrealized),
        //                    TotalGain = ticker.Total_Gain,
        //                });
        //            }
        //        }
        //    }

        //    //var list = (from Trades in db.Trades select Trades).
        //    //   GroupBy(x => x.Ticker)
        //    //   .Select(x =>
        //    //  x.OrderBy(y => y.Date).FirstOrDefault()).ToList();

        //    //return View(list);

        //    return View(tradeViewList);
         }
    }
}
