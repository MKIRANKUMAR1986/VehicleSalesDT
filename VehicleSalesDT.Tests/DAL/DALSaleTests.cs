using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSalesDT.DAL;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using System.Configuration;
using System.IO;

namespace VehicleSalesDT.Tests.DAL
{
    [TestFixture]
    public class DALSaleTests
    {
        private IDALSale _dalSale;
        private string _inputString;

        [SetUp]
        public void SetUp()
        {
            _dalSale = new DALSale();
        }

        [Test]
        public void GetParsedSalesFromCSV_InputStreamNotValid_ReturnStringList()
        {
            //Arrange
            _inputString = "Dummy";
            using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes("Dummy")))
            {
                //Act
                var result = _dalSale.GetParsedSalesFromCSV(test_Stream);

                //Assert
                Assert.That(result, Is.InstanceOf<List<string>>());
            }
        }

        [Test]
        public void GetParsedSalesFromCSV_InputStreamValid_ReturnStringListCount()
        {
            _inputString = "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date \n 5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,8/26/2018";
            //Arrange
            using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes(_inputString)))
            {
                //Act
                var result = _dalSale.GetParsedSalesFromCSV(test_Stream);

                //Assert
                Assert.That(result.Count(), Is.EqualTo(2));
            }
        }

        [Test]
        public void GetParsedSalesFromCSV_Empty_ReturnStringListZeroCount()
        {
            //Arrange
            using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes("")))
            {
                //Act
                var result = _dalSale.GetParsedSalesFromCSV(test_Stream);

                //Assert
                Assert.That(result.Count(), Is.EqualTo(0));
            }
        }
    }
}
