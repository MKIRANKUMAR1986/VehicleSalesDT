using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic
{
    public interface IBLMonthSale
    {
        IEnumerable<MonthSale> GetMonthSale(string filePath);
    }
}