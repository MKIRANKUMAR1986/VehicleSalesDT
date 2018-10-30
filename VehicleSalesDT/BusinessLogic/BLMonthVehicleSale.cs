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
    public class BLMonthVehicleSale : IBLMonthVehicleSale
    {
        private IBLCommon _common;

        public BLMonthVehicleSale(IBLCommon commonBL)
        {
            _common = commonBL;
        }
        public IEnumerable<MonthVehicleSale> GetMonthVehicleSale(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return _common.GetParsedSales(filePath)
                        .GroupBy(x => new { Convert.ToDateTime(x.SaleDate).Month , x.Vehicle})
                        .Select(a => new MonthVehicleSale { MonthId = a.Key.Month, VehicleName = a.Key.Vehicle, NumofSales = a.Count(), Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(a.Key.Month) })
                        .OrderBy(c =>  c.MonthId).ThenBy(c => c.VehicleName).ToList();
                }
                return null;
            }
            catch (Exception ex)
            { return null; }
        }
    }
}