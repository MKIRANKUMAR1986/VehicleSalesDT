using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleSalesDT.Models;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using System.Web.Http;
using System.Globalization;
using VehicleSalesDT.BusinessLogic;
using System.Web.Configuration;
using VehicleSalesDT.BusinessLogic.Shared;

namespace VehicleSalesDT.Controllers.Api
{
    public class MonthPriceController : ApiController
    {
        IBLMonthPrice _blMonthPrice = null;
        IBLCommon _blCommon = null;

        public MonthPriceController(IBLMonthPrice blMonthPrice, IBLCommon blCommon)
        {
            _blMonthPrice = blMonthPrice;
            _blCommon = blCommon;
        }

        public IEnumerable<MonthPrice> GetMonthPrice()
        {
            return _blMonthPrice.GetMonthPrice(_blCommon.GetExcelFilePath());
        }
    }
}