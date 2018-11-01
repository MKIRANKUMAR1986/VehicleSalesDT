using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace VehicleSalesDT.DAL
{
    public class DALSale : IDALSale
    {
        public DALSale()
        {

        }

        public List<string> GetParsedSalesFromCSV(Stream postedFile)
        {
            List<string> _Sales = new List<string>();
            try
            {
                using (TextFieldParser parser = new TextFieldParser(postedFile, Encoding.GetEncoding("iso-8859-1")))
                {
                    string delimiter = ",";
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(delimiter);

                    string[] fields;

                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();

                        for (int i = 0; i < fields.Count(); i++)
                            fields[i] = fields[i].Replace(delimiter, "");

                        _Sales.Add(string.Join(delimiter, fields));
                    }
                    return _Sales;
                }

            }
            catch (Exception ex)
            {
                //log exception
                _Sales.Clear();
                return _Sales;
            }
        }
    }
}