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
    public class BLDealerSale : IBLDealerSale
    {
        private IBLCommon _common;

        public BLDealerSale(IBLCommon commonBL)
        {
            _common = commonBL;
        }
        public IEnumerable<DealerSale> GetDealerSale(string filePath)
        {
            try
            {
                if (_common.CheckIfFileExists(filePath))
                {
                    return _common.GetParsedSales(filePath)
                        .GroupBy(x => x.DealershipName)
                        .Select(a => new DealerSale { DealershipName = a.Key, NumofSales = a.Count() })
                        .OrderBy(c => c.NumofSales).ToList();
                }
                return null;
            }
            catch (Exception ex)
            { return null; }
        }
    }
}