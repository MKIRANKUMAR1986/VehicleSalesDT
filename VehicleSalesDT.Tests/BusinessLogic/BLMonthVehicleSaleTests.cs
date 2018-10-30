using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.DAL;

namespace VehicleSalesDT.Tests.BusinessLogic
{
    [TestFixture]
    public class BLMonthVehicleSaleTests
    {
        private IBLMonthVehicleSale _blMonthVehicleSale;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _blMonthVehicleSale = new BLMonthVehicleSale(new BLCommon(new DALSale()));
        }

        [Test]
        public void GetMonthVehicleSale_InputFileNotValid_ReturnNull()
        {
            //Arrange
            _filePath = "sdfhskfh";

            //Act
            var result = _blMonthVehicleSale.GetMonthVehicleSale(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetMonthVehicleSale_InvalidPath_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidValidFilePath"].ToString();

            //Act
            var result = _blMonthVehicleSale.GetMonthVehicleSale(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetMonthVehicleSale_Emptyfile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["Emptyfile"].ToString();

            //Act
            var result = _blMonthVehicleSale.GetMonthVehicleSale(_filePath);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetMonthVehicleSale_ValidFile_ReturnNonEmpty()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["ValidFile"].ToString();

            //Act
            var result = _blMonthVehicleSale.GetMonthVehicleSale(_filePath);

            //Assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetMonthVehicleSale_InvalidRecordFile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidRecord"].ToString();

            //Act
            var result = _blMonthVehicleSale.GetMonthVehicleSale(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
