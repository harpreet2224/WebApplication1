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
    
    public partial class Simulation
    {
        public int Id { get; set; }
        public string Stratgy { get; set; }
        public Nullable<int> DailyOrWeekly { get; set; }
        public Nullable<int> DollerPerPosition { get; set; }
        public Nullable<int> UseAccountDollers { get; set; }
        public Nullable<int> Target { get; set; }
        public Nullable<int> ReduceBy { get; set; }
    }
}
