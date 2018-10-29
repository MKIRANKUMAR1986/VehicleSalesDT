using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleSalesDT.Models
{
    public class MonthPrice
    {
        public int MonthId { get; set; }

        public string Month { get; set; }

        public decimal? Price { get; set; }
    }
}