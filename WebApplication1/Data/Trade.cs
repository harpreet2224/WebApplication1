//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PennyApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trade
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Nullable<double> Open { get; set; }
        public Nullable<double> High { get; set; }
        public Nullable<double> Low { get; set; }
        public Nullable<double> Close { get; set; }
        public Nullable<int> Vol { get; set; }
        public Nullable<int> OI { get; set; }
    }
}
