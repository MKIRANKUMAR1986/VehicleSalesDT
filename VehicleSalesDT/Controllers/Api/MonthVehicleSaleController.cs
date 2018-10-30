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
    public class MonthVehicleSaleController : ApiController
    {
        IBLMonthVehicleSale _blMonthVehicleSale = null;
        IBLCommon _blCommon = null;

        public MonthVehicleSaleController(IBLMonthVehicleSale blMonthVehicleSale, IBLCommon blCommon)
        {
            _blMonthVehicleSale = blMonthVehicleSale;
            _blCommon = blCommon;
        }
        public IEnumerable<MonthVehicleSale> GetMonthVehicleSale()
        {
            return _blMonthVehicleSale.GetMonthVehicleSale(_blCommon.GetExcelFilePath());
        }
    }
}
