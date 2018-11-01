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
                        },
                        new Sale {
                            SaleId = 2,
                            SaleDate = Convert.ToDateTime("1/14/2018"),
                            DealerNumber = 5132,
                            CustomerName = "Rahima Skinner",
                            DealershipName = "Seven Star Dealership",
                            Vehicle = "2009 Lamborghini Gallardo Carbon Fiber LP-560",
                            Price = 169900
                        },
                        new Sale {
                            SaleId = 3,
                            SaleDate = Convert.ToDateTime("6/7/2018"),
                            DealerNumber = 5795,
                            CustomerName = "Aroush Knapp",
                            DealershipName = "Maxwell & Junior",
                            Vehicle = "2016 Porsche 911 2dr Cpe GT3 RS",
                            Price = 289900
                        },
                        new Sale {
                            SaleId = 4,
                            SaleDate = Convert.ToDateTime("7/13/2018"),
                            DealerNumber = 5212,
                            CustomerName = "Richard Spencer",
                            DealershipName = "Milton Jeep Limited",
                            Vehicle = "2018 Jeep Grand Cherokee Trackhawk",
                            Price = 134599
                        },
                        new Sale {
                            SaleId = 5,
                            SaleDate = Convert.ToDateTime("1/21/2018"),
                            DealerNumber = 5268,
                            CustomerName = "Naseem Snow",
                            DealershipName = "Scott Toronto Dealership, Inc",
                            Vehicle = "2018 BMW M760Li Xdrive Sedan",
                            Price = 177608
                        },
                        new Sale {
                            SaleId = 6,
                            SaleDate = Convert.ToDateTime("3/22/2018"),
                            DealerNumber = 5765,
                            CustomerName = "Storm William",
                            DealershipName = "Mythicgarcia Dealership LTDA",
                            Vehicle = "2018 Mercedes-Benz S-Class Cabriolet",
                            Price = 189693
                        },
                        new Sale {
                            SaleId = 7,
                            SaleDate = Convert.ToDateTime("6/21/2018"),
                            DealerNumber = 5712,
                            CustomerName = "Donald Waters",
                            DealershipName = "Milton Jeep Limited",
                            Vehicle = "2018 Jeep Grand Cherokee Trackhawk",
                            Price = 135500
                        }
            };
        }

        [Test]
        public void GetSales_InputStreamNull_ReturnListNull()
        {
            //Arrange
            _blCommon.Setup(fr => fr.GetParsedSales(It.IsAny<Stream>())).Returns(_dummySales);

            //Act
            var result = _blSale.GetSales(null);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetSales_InputStreamValid_ReturnListCountSeven()
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
                Assert.That(result.Count(), Is.EqualTo(7));
            }
        }

        [Test]
        public void GetMonthPrices_InputValidList_ReturnCount()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthPrices(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(4));
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
            Assert.That(result.Count(), Is.EqualTo(4));
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
            Assert.That(result.Count(), Is.EqualTo(6));
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

        [Test]
        public void GetVehicles_InputValidList_ReturnCount()
        {
            //Arrange

            //Act
            var result = _blSale.GetVehicles(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(6));
        }

        [Test]
        public void GetVehicles_InputEmptyList_ReturnZeroCount()
        {
            //Arrange
            _dummySales.Clear();

            //Act
            var result = _blSale.GetVehicles(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetVehicles_InputNull_ReturnNull()
        {
            //Arrange

            //Act
            var result = _blSale.GetVehicles(null);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetMonthVehicleSales_InputValidList_ReturnCount()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthVehicleSales(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(7));
        }

        [Test]
        public void GetMonthVehicleSales_InputEmptyList_ReturnZeroCount()
        {
            //Arrange
            _dummySales.Clear();

            //Act
            var result = _blSale.GetMonthVehicleSales(_dummySales);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetMonthVehicleSales_InputNull_ReturnNull()
        {
            //Arrange

            //Act
            var result = _blSale.GetMonthVehicleSales(null);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
