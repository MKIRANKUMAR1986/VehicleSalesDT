using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic
{
    public class BLMonthSale : IBLMonthSale
    {
        private IBLCommon _common;

        public BLMonthSale(IBLCommon commonBL)
        {
            _common = commonBL;
        }
        public IEnumerable<MonthSale> GetMonthSale(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return _common.GetParsedSales(filePath)
                        .GroupBy(x => Convert.ToDateTime(x.SaleDate).Month)
                        .Select(a => new MonthSale { MonthId = a.Key, NumOfSales = a.Count(), Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(a.Key) })
                        .OrderBy(c => c.MonthId).ToList();
                }
                return null;
            }
            catch (Exception ex)
            { return null; }
        }
    }
}