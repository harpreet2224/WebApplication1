using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PennyApp.Models
{
    public class Trades
    {
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public double Vol { get; set; }
        public int OI { get; set; }
        public float Moving_Avg { get; set; }

        public float Upper_BBand { get; set; }
        public float Lower_BBand { get; set; }


    }
}