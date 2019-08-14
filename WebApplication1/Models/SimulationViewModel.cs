using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PennyApp.Models
{
    public class SimulationViewModel
    {
        public int Id { get; set; }
        public string Stratgy { get; set; }
        public int DailyOrWeekly { get; set; }
        public int DollerPerPosition { get; set; }
        public bool UseAccountDollers { get; set; }
        public int Target { get; set; }
        public int ReduceBy { get; set; }
    }
}