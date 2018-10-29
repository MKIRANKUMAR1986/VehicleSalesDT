using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.DAL;

namespace VehicleSalesDT.BusinessLogic
{
    public class BLMonthPrice : IBLMonthPrice
    {
        private IBLMonthPrice _BL;

        private IBLCommon _common;

        public BLMonthPrice(IBLMonthPrice monthPriceBL)
        {
            _BL = monthPriceBL;
        }

        public BLMonthPrice()
        {

        }

        public IEnumerable<MonthPrice> GetMonthPrice(string filePath)
        {
            try
            {
                _common = new BLCommon(new DALSale());
                if (File.Exists(filePath))
                {
                    return _common.GetParsedSales(filePath)
                        .GroupBy(x => Convert.ToDateTime(x.SaleDate).Month)
                        .Select(a => new MonthPrice { MonthId = a.Key, Price = a.Sum(b => b.Price), Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(a.Key) })
                        .OrderBy(c => c.MonthId).ToList();
                }
                return null;
            }
            catch (Exception ex)
            { return null; }
        }
    }
}