using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;
using VehicleSalesDT.DAL;
using Microsoft.VisualBasic.FileIO;
using System.Web.Configuration;
using System.IO;

namespace VehicleSalesDT.BusinessLogic.Shared
{
    public class BLCommon : IBLCommon
    {
        private IDALSale _dalSale;

        public BLCommon(IDALSale dalSale)
        {
            _dalSale = dalSale;
        }

        public IEnumerable<Sale> GetParsedSales(string filePath)
        {
            try
            {
                using (TextFieldParser parser = _dalSale.GetParsedSalesFromCSV(filePath))
                {
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(",");

                    string[] fields;

                    List<Sale> _Sales = new List<Sale>();
                    var SaleId = 1;

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        if (SaleId > 1)
                        {
                            if (ValidateExcelFileFields(fields))
                            {
                                Sale sale = new Sale()
                                {
                                    SaleId = SaleId,
                                    DealerNumber = Convert.ToInt32(fields[0]),
                                    CustomerName = fields[1],
                                    DealershipName = fields[2],
                                    Vehicle = fields[3],
                                    Price = Convert.ToDecimal(fields[4]),
                                    SaleDate = Convert.ToDateTime(fields[5])
                                };
                                _Sales.Add(sale);
                                SaleId++;
                            }
                            else { return null; }
                        }
                        else
                        {
                            SaleId++;
                        }
                    }
                    return _Sales;
                }
            }
            catch (Exception ex)
            { return null; }
        }

        public string GetExcelFilePath()
        {
            if (WebConfigurationManager.AppSettings[Constants.EXCEL_FILE_FOLDER_NAME] != null && WebConfigurationManager.AppSettings[Constants.EXCEL_FILE_NAME] != null)
                return Path.Combine(HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings[Constants.EXCEL_FILE_FOLDER_NAME].Trim().ToString()), WebConfigurationManager.AppSettings[Constants.EXCEL_FILE_NAME].Trim().ToString());
            else
                return Path.Combine(HttpContext.Current.Server.MapPath(Constants.EXCEL_FILE_FOLDER_NAME), Constants.EXCEL_FILE_NAME); 
        }

        private bool ValidateExcelFileFields(string[] fields)
        {
            int num;
            decimal dec;
            DateTime temp;

            foreach (var field in fields)
            {
                if (field == null)
                    return false;
            }

            if (!int.TryParse(fields[0].ToString(), out num))
            {
                return false;
            }
            else if(!decimal.TryParse(fields[0].ToString(), out dec))
            {
                return false;
            }
            else if (!DateTime.TryParse(fields[5].ToString(), out temp))
            {
                return false;
            }
            return true;
        }

        public bool CheckIfFileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}