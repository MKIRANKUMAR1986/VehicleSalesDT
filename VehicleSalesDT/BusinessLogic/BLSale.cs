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

namespace VehicleSalesDT.BusinessLogic
{
    public class BLSale : IBLSale
    {
        private IBLSale _BL;

        private IBLCommon _common;

        public BLSale(IBLSale saleBL)
        {
            _BL = saleBL;
        }

        public BLSale()
        {
            
        }

        public IEnumerable<Sale> GetSales(string filePath)
        {
            try
            {
                _common = UnityConfig.Retrieve<BLCommon>();

                if (File.Exists(filePath))
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
                _common = UnityConfig.Retrieve<BLCommon>();
                if (postedFile != null)
                {
                    postedFile.SaveAs(filePath);

                    return _common.GetParsedSales(filePath);
                }
                return null;
            }
            catch (Exception ex) {
                return null;
            }
            
        }
    }
}