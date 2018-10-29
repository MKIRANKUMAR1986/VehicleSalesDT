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

namespace VehicleSalesDT.Controllers.Api
{
    public class MonthPriceController : ApiController
    {
        string _filePath = "";

        IEnumerable<MonthPrice> _monthPrices = null;

        IBLMonthPrice _blMonthPrice = null;

        public MonthPriceController(IBLMonthPrice blMonthPrice)
        {
            _blMonthPrice = blMonthPrice;
        }

        public MonthPriceController()
        {
            
        }

        // GET: Sale
        public IEnumerable<MonthPrice> GetMonthPrice()
        {
            _blMonthPrice = new BLMonthPrice();
            _filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "Dealertrack.csv");
            _monthPrices = _blMonthPrice.GetMonthPrice(_filePath);

            return _monthPrices;
        }
    }
}