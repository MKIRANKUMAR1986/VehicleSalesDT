using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleSalesDT.DAL
{
    public interface IDALSale
    {
        TextFieldParser GetParsedSalesFromCSV(string filePath);
    }
}