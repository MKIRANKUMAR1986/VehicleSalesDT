using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using VehicleSalesDT.Models;
using VehicleSalesDT.DAL;
using VehicleSalesDT.BusinessLogic.Shared;
using System.IO;
using Unity;
using VehicleSalesDT.Unity;
using System.Globalization;

namespace VehicleSalesDT.BusinessLogic
{
    public class BLSale : IBLSale
    {
        private IBLCommon _common;

        public BLSale(IBLCommon commonBL)
        {
            _common = commonBL;
        }

        public IEnumerable<Sale> GetSales(string filePath)
        {
            try
            {
                if (_common.CheckIfFileExists(filePath))
                {
                     return _common.GetParsedSales(filePath); 
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Sale> GetSales(HttpPostedFileBase postedFile, string filePath)
        {
            try
            {
                if (postedFile != null)
                {
                    postedFile.SaveAs(filePath);

                    return _common.GetParsedSales(filePath);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<MonthPrice> GetMonthPrices(IEnumerable<Sale> sales)
        {
            try
            {
                return sales
                    .GroupBy(x => Convert.ToDateTime(x.SaleDate).Month)
                    .Select(a => new MonthPrice { MonthId = a.Key, Price = a.Sum(b => b.Price), Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(a.Key) })
                    .OrderBy(c => c.MonthId).ToList();
            }
            catch (Exception ex)
            { return null; }
        }

        public IEnumerable<MonthSale> GetMonthSales(IEnumerable<Sale> sales)
        {
            try
            {
                return sales
                    .GroupBy(x => Convert.ToDateTime(x.SaleDate).Month)
                    .Select(a => new MonthSale { MonthId = a.Key, NumOfSales = a.Count(), Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(a.Key) })
                    .OrderBy(c => c.MonthId).ToList();
            }
            catch (Exception ex)
            { return null; }
        }
        public IEnumerable<DealerSale> GetDealerSales(IEnumerable<Sale> sales)
        {
            try
            {
                return sales
                        .GroupBy(x => x.DealershipName)
                        .Select(a => new DealerSale { DealershipName = a.Key, NumofSales = a.Count() })
                        .OrderBy(c => c.NumofSales).ToList();
            }
            catch (Exception ex)
            { return null; }
        }
    }
}