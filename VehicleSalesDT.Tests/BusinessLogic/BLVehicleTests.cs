using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.VisualBasic.FileIO;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.DAL;
using System.Configuration;
using VehicleSalesDT.Models;

namespace VehicleSalesDT.Tests.BusinessLogic
{
    [TestFixture]
    public class BLVehicleTests
    {
        private IBLVehicle _blVehicle;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _blVehicle = new BLVehicle(new BLCommon(new DALSale()));
        }

        [Test]
        public void GetVehicles_InputFileNotValid_ReturnNull()
        {
            //Arrange
            _filePath = "sdfhskfh";

            //Act
            var result = _blVehicle.GetVehicles(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetVehicles_InvalidPath_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidValidFilePath"].ToString();

            //Act
            var result = _blVehicle.GetVehicles(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetVehicles_Emptyfile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["Emptyfile"].ToString();

            //Act
            var result = _blVehicle.GetVehicles(_filePath);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetVehicles_ValidFile_ReturnNonEmpty()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["ValidFile"].ToString();

            //Act
            var result = _blVehicle.GetVehicles(_filePath);

            //Assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetVehicles_InvalidRecordFile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidRecord"].ToString();

            //Act
            var result = _blVehicle.GetVehicles(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
