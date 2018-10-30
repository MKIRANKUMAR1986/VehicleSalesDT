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
using Microsoft.Practices.Unity;
using Unity;
using System.Web.Configuration;
using VehicleSalesDT.BusinessLogic.Shared;

namespace VehicleSalesDT.Controllers.Api
{
    public class SaleController : ApiController
    {
        IBLSale _blSale = null;
        IBLCommon _blCommon = null;

        public SaleController(IBLSale saleBL, IBLCommon blCommon)
        {
            _blSale = saleBL;
            _blCommon = blCommon;
        }

        public IEnumerable<Sale> GetSales()
        {            
            return _blSale.GetSales(_blCommon.GetExcelFilePath());
        }

        //[System.Web.Mvc.HttpPost]
        //public IEnumerable<Sale> Sales()
        //{
        //    var attachedFile = System.Web.HttpContext.Current.Request.Files["CsvDoc"];

        //    bool isUploaded = false;
        //    string filePath = string.Empty;
        //    string message = "File upload failed";

        //    for (int i = 0; i < System.Web.HttpContext.Current.Request.Files.Count; i++)
        //    {
        //        var myFile = System.Web.HttpContext.Current.Request.Files[i];

        //        if (myFile != null && myFile.ContentLength != 0)
        //        {
        //            string pathForSaving = HttpContext.Current.Server.MapPath("~/App_Data");
        //            if (!Directory.Exists(pathForSaving))
        //            {
        //                Directory.CreateDirectory(pathForSaving);
        //            }
        //            try
        //            {
        //                filePath = Path.Combine(pathForSaving, myFile.FileName);
        //                myFile.SaveAs(filePath);
        //                isUploaded = true;
        //                message = "File uploaded successfully!";
        //            }
        //            catch (Exception ex)
        //            {
        //                message = string.Format("File upload failed: {0}", ex.Message);
        //            }
        //        }

        //    }
        //    TextFieldParser parser = new TextFieldParser(filePath);
        //    parser.HasFieldsEnclosedInQuotes = true;
        //    parser.SetDelimiters(",");

        //    string[] fields;

        //    List<Sale> _Sales = new List<Sale>();
        //    var SaleId = 1;

        //    while (!parser.EndOfData)
        //    {
        //        fields = parser.ReadFields();
        //        if (SaleId > 1)
        //        {
        //            Sale sale = new Sale()
        //            {
        //                SaleId = SaleId,
        //                DealerNumber = Convert.ToInt32(fields[0]),
        //                CustomerName = fields[1],
        //                DealershipName = fields[2],
        //                Vehicle = fields[3],
        //                Price = Convert.ToDecimal(fields[4]),
        //                SaleDate = Convert.ToDateTime(fields[5])
        //            };
        //            _Sales.Add(sale);
        //            SaleId++;
        //        }
        //        else
        //        {
        //            SaleId++;
        //        }
        //    }

        //    parser.Close();
        //    return _Sales;
        //}
    }
}