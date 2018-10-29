using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic.Shared
{
    public interface IBLCommon
    {
        IEnumerable<Sale> GetParsedSales(string filePath);
    }
}