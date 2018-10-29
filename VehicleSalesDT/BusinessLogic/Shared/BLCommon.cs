using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;
using VehicleSalesDT.DAL;
using Microsoft.VisualBasic.FileIO;

namespace VehicleSalesDT.BusinessLogic.Shared
{
    public class BLCommon : IBLCommon
    {
        private IDALSale _dalSale;

        public BLCommon()
        {

        }

        public BLCommon(IDALSale dalSale)
        {
            _dalSale = dalSale;
        }

        public IEnumerable<Sale> GetParsedSales(string filePath)
        {
            TextFieldParser parser = _dalSale.GetParsedSalesFromCSV(filePath);
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
                else
                {
                    SaleId++;
                }
            }

            parser.Close();
            return _Sales;
        }
    }
}