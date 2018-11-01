using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.BusinessLogic.Shared
{
    public interface IBLCommon
    {
        IEnumerable<Sale> GetParsedSales(Stream postedFile);
    }
}