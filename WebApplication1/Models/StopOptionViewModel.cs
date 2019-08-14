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

        public bool Stop_Option1 { get; set; }

        public List<ValueModel>stop_option_drop {get;set;}
        public int Stop_Option_Status { get; set; }
        public List<ValueModel> Stop_Option_Value { get; set; }

        public bool Stop_Option_check { get; set; }

        public int Trial_Stop { get; set; }
        public List<ValueModel> Trial_Stop_Status { get; set; }
        public bool Trial_Stop_Value { get; set; }
        public bool Price_On { get; set; }
        public int Price_Status { get; set; }
        public int Price_ValueFrom { get; set; }
        public int Price_ValueTo { get; set; }
        public List<ValueModel> Price_value_check { get; set; }

        public bool Volume_On { get; set; }
        public int Volume_Status { get; set; }
        public int Volume_status1 { get; set; }
        public int Volume_status2 { get; set; }
        public List<ValueModel> Volume_check { get; set; }
        public int Avg_Volume_On { get; set; }
        public bool Avg_Volume_check { get; set; }
        public List<ValueModel> Avg_Volume_Status { get; set; }
        public int Avg_Volume_Value1 { get; set; }
        public int Avg_Volume_Value2 { get; set; }
    }
}