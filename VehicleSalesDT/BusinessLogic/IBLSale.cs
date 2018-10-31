using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic
{
    public interface IBLSale
    {
        IEnumerable<Sale> GetSales(string filePath);

        IEnumerable<Sale> GetSales(HttpPostedFileBase postedFile, string filePath);

        IEnumerable<MonthPrice> GetMonthPrices(IEnumerable<Sale> sales);

        IEnumerable<MonthSale> GetMonthSales(IEnumerable<Sale> sales);

        IEnumerable<DealerSale> GetDealerSales(IEnumerable<Sale> sales);

    }
    
}