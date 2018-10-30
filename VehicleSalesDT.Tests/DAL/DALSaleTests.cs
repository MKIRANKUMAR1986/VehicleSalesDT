using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSalesDT.DAL;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using System.Configuration;

namespace VehicleSalesDT.Tests.DAL
{
    [TestFixture]
    public class DALSaleTests 
    {
        private IDALSale _dalSale;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _dalSale = new DALSale();
        }
        [Test]
        public void GetParsedSalesFromCSV_InputFileNotValid_ReturnNull()
        {
            //Arrange
            _filePath = "sdfhskfh";

            //Act
            var result = _dalSale.GetParsedSalesFromCSV("sdfhskfh");

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetParsedSalesFromCSV_InputFileValid_ReturnTextFieldParseFile()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["ValidFile"].ToString();           

            //Act
            var result = _dalSale.GetParsedSalesFromCSV(_filePath);

            //Assert
            Assert.That(result, Is.InstanceOf<TextFieldParser>());
        }

        [Test]
        public void GetParsedSalesFromCSV_InvalidPath_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidValidFilePath"].ToString();

            //Act
            var result = _dalSale.GetParsedSalesFromCSV(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetParsedSalesFromCSV_ValidPathWordDocFile_ReturnTextFieldParseFile()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["WordDoc"].ToString();

            //Act
            var result = _dalSale.GetParsedSalesFromCSV(_filePath);

            //Assert
            Assert.That(result, Is.InstanceOf<TextFieldParser>());
        }
    }
}
