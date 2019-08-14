using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennyApp.Models
{
    public class TradeViewModel
    {
        public int id { get; set; }
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public string Open { get; set; }
        public int? Amount { get; set; }
        public int? Entrypx { get; set; }
        public int? Exit1 { get; set; }
        public double? PriceNow { get; set; }
        public int? Realized { get; set; }
        public int? Unrealized { get; set; }
        public double? TotalGain { get; set; }
    }
}