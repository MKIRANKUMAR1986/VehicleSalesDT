using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleSalesDT.DAL
{
    public class DALSale : IDALSale
    {
        public DALSale()
        {

        }

        public TextFieldParser GetParsedSalesFromCSV(string filePath)
        {
            try
            {
                return new TextFieldParser(filePath);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}