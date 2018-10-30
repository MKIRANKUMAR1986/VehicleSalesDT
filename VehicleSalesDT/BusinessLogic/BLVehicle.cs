using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic
{
    public class BLVehicle : IBLVehicle
    {
        private IBLCommon _common;

        public BLVehicle(IBLCommon commonBL)
        {
            _common = commonBL;
        }
        public IEnumerable<Vehicle> GetVehicles(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return _common.GetParsedSales(filePath)
                        .GroupBy(x => x.Vehicle)
                        .Select(a => new Vehicle { VehicleName = a.Key })
                        .OrderBy(c => c.VehicleName).ToList();
                }
                return null;
            }
            catch (Exception ex)
            { return null; }
        }
    }
}