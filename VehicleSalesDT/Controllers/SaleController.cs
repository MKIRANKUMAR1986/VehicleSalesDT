using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleSalesDT.Models;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.Unity;
using Unity.Attributes;
using VehicleSalesDT.BusinessLogic.Shared;

namespace VehicleSalesDT.Controllers
{
    public class SaleController : Controller
    {
        IEnumerable<Sale> _sales = null;

        IBLSale _blSale = null;
        IBLCommon _blCommon = null;

        public SaleController(IBLSale saleBL, IBLCommon blCommon)
        {
            _blSale = saleBL;
            _blCommon = blCommon;
        }

        // GET: Sales
        public ActionResult Index()
        {
            //var sales = new List<Sale>
            //    {
            //        new Sale {
            //            SaleId = 1,
            //            SaleDate = Convert.ToDateTime("6/19/2018"),
            //            DealerNumber = 5469,
            //            CustomerName = "Milli Fulton",
            //            DealershipName = "Sun of Saskatoon",
            //            Vehicle = "2017 Ferrari 488 Spider",
            //            Price = 429987
            //        }
            //    };
            _sales = _blSale.GetSales(_blCommon.GetExcelFilePath());

            if(_sales != null)
            {
                var temp = _sales
                                .GroupBy(x => x.Vehicle)
                                .Select(a => new { Vehicle = a.Key, NumOfTimes = a.Count() })
                                .OrderByDescending(d => d.NumOfTimes)
                                .Take(1)
                                .Select(a => a.Vehicle).ToList();

                ViewData["MostOftenVehicle"] = temp.FirstOrDefault();
            }

            return View(_sales);
        }

        // POST: Sale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            _sales = _blSale.GetSales(postedFile, _blCommon.GetExcelFilePath());

            if (_sales != null)
            {
                var temp = _sales
                                .GroupBy(x => x.Vehicle)
                                .Select(a => new { Vehicle = a.Key, NumOfTimes = a.Count() })
                                .OrderByDescending(d => d.NumOfTimes)
                                .Take(1)
                                .Select(a => a.Vehicle).ToList();

                ViewData["MostOftenVehicle"] = temp.FirstOrDefault();
            }
            else
            {
                ViewData["Message"] = "There are errors in the CSV file. Please Correct it and Re-Upload";
            }
            return View(_sales);
        }
        //public List<Sale> GetSales1()
        //{
        //    String[] csv = System.IO.File.ReadAllLines(Path.Combine(Server.MapPath("~/App_Data"), "Dealertrack-CSV-Example.csv"));
        //    List<Sale> Sales = new List<Sale>();
        //    var SaleId = 1;
        //    foreach (string csvrow in csv)
        //    {
        //        var fields = csvrow.Split(',');
        //        if (SaleId > 1)
        //        {
        //            Sale sale = new Sale()
        //            {
        //                SaleId = SaleId,
        //                DealerNumber = Convert.ToInt32(fields[0]),
        //                CustomerName = fields[1],
        //                DealershipName = fields[2],
        //                Vehicle = fields[3]
        //                //Price = Convert.ToDecimal(fields[4]),
        //                //SaleDate = Convert.ToDateTime(fields[5])
        //            };
        //            Sales.Add(sale);
        //            SaleId++;
        //        }
        //        else {
        //            SaleId++;
        //        }
        //    }
        //    return Sales;
        //}

        //public List<Sale> GetSales(string filePath)
        //{
        //    TextFieldParser parser = new TextFieldParser(filePath);
        //    parser.HasFieldsEnclosedInQuotes = true;
        //    parser.SetDelimiters(",");

        //    string[] fields;

        //    List<Sale> Sales = new List<Sale>();
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
        //            Sales.Add(sale);
        //            SaleId++;
        //        }
        //        else
        //        {
        //            SaleId++;
        //        }
        //    }

        //    parser.Close();
        //    var temp = Sales
        //                .GroupBy(x => x.Vehicle)
        //                .Select(a => new  { Vehicle = a.Key, NumOfTimes = a.Count() })
        //                .OrderByDescending(d => d.NumOfTimes)
        //                .Take(1)
        //                .Select(a => a.Vehicle).ToList();
        //                            ViewData["MostOftenVehicle"] = temp.FirstOrDefault();
        //    return Sales;
        //}
    }
}