using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VehicleSalesDT.DAL
{
    public interface IDALSale
    {
        List<string> GetParsedSalesFromCSV(Stream postedFile);
    }
}