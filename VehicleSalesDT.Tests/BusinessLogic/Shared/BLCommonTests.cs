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

namespace VehicleSalesDT.Tests.BusinessLogic.Shared
{
    [TestFixture]
    public class BLCommonTests
    {
        private IBLCommon _blCommon;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            _blCommon = new BLCommon(new DALSale());
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
        public void GetParsedSales_InputFileNotValid_ReturnNull()
        {
            //Arrange
            _filePath = "sdfhskfh";

            //Act
            var result = _blCommon.GetParsedSales(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetParsedSales_InvalidPath_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidValidFilePath"].ToString();

            //Act
            var result = _blCommon.GetParsedSales(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetParsedSales_Emptyfile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["Emptyfile"].ToString();

            //Act
            var result = _blCommon.GetParsedSales(_filePath);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetParsedSales_ValidFile_ReturnNonEmpty()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["ValidFile"].ToString();

            //Act
            var result = _blCommon.GetParsedSales(_filePath);

            //Assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GetParsedSales_InvalidRecordFile_ReturnNull()
        {
            //Arrange
            _filePath = ConfigurationManager.AppSettings["InvalidRecord"].ToString();

            //Act
            var result = _blCommon.GetParsedSales(_filePath);

            //Assert
            Assert.That(result, Is.Null);
        }
    }
}
