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
    public class VehicleController : ApiController
    {
        IBLVehicle _blVehicle = null;
        IBLCommon _blCommon = null;

        public VehicleController(IBLVehicle blVehicle, IBLCommon blCommon)
        {
            _blVehicle = blVehicle;
            _blCommon = blCommon;
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _blVehicle.GetVehicles(_blCommon.GetExcelFilePath());
        }
    }
}
