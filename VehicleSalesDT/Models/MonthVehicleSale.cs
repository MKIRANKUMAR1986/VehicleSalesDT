using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleSalesDT.Models
{
    public class MonthVehicleSale
    {
        public int MonthId { get; set; }

        public string Month { get; set; }

        public string VehicleName { get; set; }

        public int? NumofSales { get; set; }
    }
}