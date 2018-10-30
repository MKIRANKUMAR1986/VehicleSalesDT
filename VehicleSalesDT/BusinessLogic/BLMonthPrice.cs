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
        private IBLCommon _common;

        public BLMonthPrice(IBLCommon commonBL)
        {
            _common = commonBL;
        }

        public IEnumerable<MonthPrice> GetMonthPrice(string filePath)
        {
            try
            {
                if (_common.CheckIfFileExists(filePath))
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