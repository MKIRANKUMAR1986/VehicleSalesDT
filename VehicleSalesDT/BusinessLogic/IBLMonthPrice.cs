using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic
{
    public interface IBLMonthPrice
    {
        IEnumerable<MonthPrice> GetMonthPrice(string filePath);
    }
}