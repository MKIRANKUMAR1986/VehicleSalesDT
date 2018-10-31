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
using Moq;

namespace VehicleSalesDT.Tests.BusinessLogic.Shared
{
    [TestFixture]
    public class BLCommonTests
    {
        private IBLCommon _blCommon;
        private string _filePath;
        private Mock<IDALSale> _dalSale;

        [SetUp]
        public void SetUp()
        {
            //Arrange            
            _dalSale = new Mock<IDALSale>();
            _blCommon = new BLCommon(_dalSale.Object);
        }

        [Test]
        public void CheckIfFileExists_InputFileNotValid_ReturnNull()
        {
            //Arrange
            _filePath = "sdfhskfh";

            //Act
            var result = _blCommon.CheckIfFileExists(_filePath);

            //Assert
            Assert.That(result, Is.False);
        }
        [Test]
        public void CheckIfFileExists_InvalidPath_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidValidFilePath"].ToString();

            //Act
            var result = _blCommon.CheckIfFileExists(_filePath);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CheckIfFileExists_Emptyfile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["Emptyfile"].ToString();

            //Act
            var result = _blCommon.CheckIfFileExists(_filePath);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckIfFileExists_ValidFile_ReturnNonEmpty()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["ValidFile"].ToString();

            //Act
            var result = _blCommon.CheckIfFileExists(_filePath);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CheckIfFileExists_InvalidRecordFile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidRecord"].ToString();

            //Act
            var result = _blCommon.CheckIfFileExists(_filePath);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetParsedSales_Empty_ReturnZeroCount()
        {
            //Arrange
            List<string> emptyList = new List<string> { };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(emptyList);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetParsedSales_ValidData_ReturnCount()
        {
            //Arrange
            List<string> validList = new List<string> {
                "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date",
                "5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,6/19/2018",
                "5324,Richard Spencer,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,395774,8/26/2018",
                "5634,Storm William,Scott Toronto Dealership Inc,2018 BMW M760Li Xdrive Sedan,305435,3/12/2018"
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(validList);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void GetParsedSales_PriceisNonDecimal_ReturnEmptyList()
        {
            //Arrange
            List<string> priceNotDecimalList = new List<string> {
                "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date",
                "5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,6/19/2018",
                "5324,Richard Spencer,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,395774,8/26/2018",
                "5634,Storm William,Scott Toronto Dealership Inc,2018 BMW M760Li Xdrive Sedan,fdg,3/12/2018"
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(priceNotDecimalList);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetParsedSales_OneColumnDataMissing_ReturnEmptyList()
        {
            //Arrange
            List<string> oneColumnDataMissingList = new List<string> {
                "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date",
                "5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987",
                "5324,Richard Spencer,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,395774,8/26/2018",
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(oneColumnDataMissingList);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GetParsedSales_OnlyHeadersCSV_ReturnSalesZeroCount()
        {
            //Arrange
            List<string> onlyHeadersList = new List<string> {
                "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date"
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(onlyHeadersList);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetParsedSales_AdditionalColumnAfter6thColumns_ReturnCount()
        {
            //Arrange
            List<string> additionalListColumnAtEnd = new List<string> {
                "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date,SalePerson",
                "5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,8/26/2018,Mark",
                "5324,Richard Spencer,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,395774,8/26/2018,Will",
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(additionalListColumnAtEnd);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetParsedSales_AdditionalColumnAtFirstColumns_ReturnZeroCount()
        {
            //Arrange
            List<string> additionalListColumnAtBeginning = new List<string> {
                "SaleId,DealNumber,CustomerName,DealershipName,Vehicle,Price,Date",
                "1,5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,8/26/2018",
                "2,5324,Richard Spencer,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,395774,8/26/2018",
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(additionalListColumnAtBeginning);

            //Act
            var result = _blCommon.GetParsedSales("");

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetParsedSales_ValidData_ReturnSum825761()
        {
            //Arrange
            List<string> additionalListColumnAtEnd = new List<string> {
                "DealNumber,CustomerName,DealershipName,Vehicle,Price,Date",
                "5469,Milli Fulton,Sun of Saskatoon,2017 Ferrari 488 Spider,429987,8/26/2018",
                "5324,Richard Spencer,Maxwell & Junior,2016 Porsche 911 2dr Cpe GT3 RS,395774,8/26/2018",
            };
            _dalSale.Setup(fr => fr.GetParsedSalesFromCSV("")).Returns(additionalListColumnAtEnd);

            //Act
            var result = _blCommon.GetParsedSales("").Sum(t => t.Price).ToString();

            //Assert
            Assert.That(result, Is.EqualTo("825761"));
        }
    }
}
