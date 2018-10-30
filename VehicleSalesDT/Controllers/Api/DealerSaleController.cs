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
    public class DealerSaleController : ApiController
    {
        IBLDealerSale _blDealerSale = null;
        IBLCommon _blCommon = null;

        public DealerSaleController(IBLDealerSale blMonthPrice, IBLCommon blCommon)
        {
            _blDealerSale = blMonthPrice;
            _blCommon = blCommon;
        }
        public IEnumerable<DealerSale> GetDealerSale()
        {
            return _blDealerSale.GetDealerSale(_blCommon.GetExcelFilePath());
        }
    }
}
