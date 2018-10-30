using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.Controllers.Api
{
    public class MonthSaleController : ApiController
    {
        IBLMonthSale _blMonthSale = null;
        IBLCommon _blCommon = null;

        public MonthSaleController(IBLMonthSale blMonthSale, IBLCommon blCommon)
        {
            _blMonthSale = blMonthSale;
            _blCommon = blCommon;
        }

        public IEnumerable<MonthSale> GetMonthSale()
        {
            return _blMonthSale.GetMonthSale(_blCommon.GetExcelFilePath());
        }
    }
}
