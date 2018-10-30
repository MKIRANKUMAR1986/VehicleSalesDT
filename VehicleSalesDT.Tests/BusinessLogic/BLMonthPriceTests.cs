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

namespace VehicleSalesDT.Tests.BusinessLogic
{
    [TestFixture]
    public class BLMonthPriceTests
    {
        private IBLMonthPrice _blMonthPrice;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _blMonthPrice = new BLMonthPrice(new BLCommon(new DALSale()));
        }
        [Test]
        public void GetMonthPrice_InputFileNotValid_ReturnNull()
        {
            //Arrange
            _filePath = "sdfhskfh";

            //Act
            var result = _blMonthPrice.GetMonthPrice(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetMonthPrice_InvalidPath_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidValidFilePath"].ToString();

            //Act
            var result = _blMonthPrice.GetMonthPrice(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetMonthPrice_Emptyfile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["Emptyfile"].ToString();

            //Act
            var result = _blMonthPrice.GetMonthPrice(_filePath);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetMonthPrice_ValidFile_ReturnNonEmpty()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["ValidFile"].ToString();

            //Act
            var result = _blMonthPrice.GetMonthPrice(_filePath);

            //Assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetMonthPrice_InvalidRecordFile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidRecord"].ToString();

            //Act
            var result = _blMonthPrice.GetMonthPrice(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
