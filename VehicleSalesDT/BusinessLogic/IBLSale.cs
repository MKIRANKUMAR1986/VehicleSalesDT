using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic
{
    public interface IBLSale
    {
        IEnumerable<Sale> GetSales(Stream postedFile);

        IEnumerable<MonthPrice> GetMonthPrices(IEnumerable<Sale> sales);

        IEnumerable<MonthSale> GetMonthSales(IEnumerable<Sale> sales);

        IEnumerable<DealerSale> GetDealerSales(IEnumerable<Sale> sales);

        IEnumerable<MonthVehicleSale> GetMonthVehicleSales(IEnumerable<Sale> sales);

        IEnumerable<Vehicle> GetVehicles(IEnumerable<Sale> sales);

    }
    
}