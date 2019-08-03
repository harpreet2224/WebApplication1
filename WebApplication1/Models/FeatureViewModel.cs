using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennyApp.Models
{
    public class FeatureViewModel
    {
        public int id { get; set; }
        public bool Moving_Avg { get; set; }
        public List<ValueModel> Moving_Avg_Value { get; set; }
        public int Moving_Avg_Filter { get; set; }
        public bool Volume { get; set; }
        public int Volume_Filter { get; set; }
        public List<ValueModel> Volume_Filter_Value { get; set; }
        public bool Day_High { get; set; }
        public List<ValueModel> Day_High_Value { get; set; }
        public bool Performance { get; set; }
        public List<ValueModel> Performance_Value { get; set; }
        public bool Consecutive_High { get; set; }
        public bool Consecutive_Low { get; set; }
        public int Consecutive_Low_Filter { get; set; }
        public bool RSI { get; set; }
        public int RSIfrom { get; set; }
        public int RSIto { get; set; }
        public List<ValueModel> RSI_Value { get; set; }
        public bool Stochastics { get; set; }
        public int StochasticsFrom { get; set; }
        public int StochasticsTo { get; set; }
        public List<ValueModel> Stochastics_Value { get; set; }
        public bool MACD_Hist { get; set; }
        public int MACD_HistTo { get; set; }
        public int MACD_HistFrom { get; set; }
        public List<ValueModel> MACD_Hist_Value { get; set; }
        public bool Upper_BBand { get; set; }
        public int Upper_BBandFrom { get; set; }
        public int Upper_BBandTo { get; set; }
        public List<ValueModel> Upper_BBand_Value { get; set; }
        public bool Lower_BBand { get; set; }
        public int Lower_BBandFrom { get; set; }
        public int Lower_BBandTo { get; set; }
        public List<ValueModel> Lower_BBand_Value { get; set; }
    }
}