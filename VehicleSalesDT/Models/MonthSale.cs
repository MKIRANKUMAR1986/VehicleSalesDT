using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleSalesDT.Models
{
    public class MonthSale
    {
        public int MonthId { get; set; }

        public string Month { get; set; }

        public int? NumOfSales { get; set; }
    }
}