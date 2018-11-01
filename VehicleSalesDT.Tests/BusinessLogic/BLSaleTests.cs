using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.DAL;
using System.Configuration;
using NUnit.Framework;
using System.IO;
using Moq;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.Tests.BusinessLogic
{
    [TestFixture]
    public class BLSaleTests
    {
        private IBLSale _blSale;
        private string _inputString;
        private Mock<IBLCommon> _blCommon;
        private List<Sale> _dummySales;

        [SetUp]
        public void SetUp()
        {
            _blCommon = new Mock<IBLCommon>();
            _blSale = new BLSale(_blCommon.Object);
            _dummySales = new List<Sale> {
                        new Sale {
                            SaleId = 1,
                            SaleDate = Convert.ToDateTime("6/19/2018"),
                            DealerNumber = 5469,
                            CustomerName = "Milli Fulton",
                            DealershipName = "Sun of Saskatoon",
                            Vehicle = "2017 Ferrari 488 Spider",
                            Price = 429987
                        }
            };
        }

        [Test]
        public void GetSales_InputStreamNull_ReturnListNull()
        {
            //Arrange
            _inputString = "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date";
            _blCommon.Setup(fr => fr.GetParsedSales(It.IsAny<Stream>())).Returns(_dummySales);

            //Act
            var result = _blSale.GetSales(null);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetSales_InputStreamValid_ReturnListCountOne()
        {
            //Arrange
            _inputString = "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date \n 5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,8/26/2018";

            using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes(_inputString)))
            {
                //Arrange
                _blCommon.Setup(fr => fr.GetParsedSales(It.IsAny<Stream>())).Returns(_dummySales);

                //Act
                var result = _blSale.GetSales(test_Stream);

                //Assert
                Assert.That(result.Count(), Is.EqualTo(1));
            }
        }

        [Test]
        public void GetMonthPrices_InputValidList_ReturnCount()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthPrices(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetMonthPrices_InputEmptyList_ReturnZeroCount()
        {
            //Arrange
            _dummySales.Clear();

            //Act
            var result = _blSale.GetMonthPrices(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetMonthPrices_InputNull_ReturnNull()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthPrices(null);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetMonthSales_InputValidList_ReturnCount()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthSales(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetMonthSales_InputEmptyList_ReturnZeroCount()
        {
            //Arrange
            _dummySales.Clear();

            //Act
            var result = _blSale.GetMonthSales(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetMonthSales_InputNull_ReturnNull()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthSales(null);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetDealerSales_InputValidList_ReturnCount()
        {
            //Arrange

            //Act
            var result = _blSale.GetDealerSales(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetDealerSales_InputEmptyList_ReturnZeroCount()
        {
            //Arrange
            _dummySales.Clear();

            //Act
            var result = _blSale.GetDealerSales(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetDealerSales_InputNull_ReturnNull()
        {
            //Arrange

            //Act
            var result = _blSale.GetDealerSales(null);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
