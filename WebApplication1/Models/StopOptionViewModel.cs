using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennyApp.Models
{
    public class StopOptionViewModel
    {
        public int id { get; set; }
        public int Stop_Option { get; set; }
        public int Stop_Option_Status { get; set; }
        public int Stop_Option_Value { get; set; }
        public int Trial_Stop { get; set; }
        public int Trial_Stop_Status { get; set; }
        public int Trial_Stop_Value { get; set; }
        public int Price_On { get; set; }
        public int Price_Status { get; set; }
        public int Price_ValueFrom { get; set; }
        public int Price_ValueTo { get; set; }
        public int Volume_On { get; set; }
        public int Volume_Status { get; set; }
        public int Avg_Volume_On { get; set; }
        public int Avg_Volume_Status { get; set; }
        public int Avg_Volume_Value1 { get; set; }
        public int Avg_Volume_Value2 { get; set; }
    }
}