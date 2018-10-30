using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.Controllers.Api;
using VehicleSalesDT.DAL;

namespace VehicleSalesDT.Tests.Controllers.Api
{
    [TestFixture]
    public class SaleControllerTests
    {
        private IBLSale _blSale;
        private Mock<IBLCommon> _blCommon;

        [SetUp]
        public void SetUp()
        {
            //Arrange            
            _blCommon = new Mock<IBLCommon>();
            _blCommon.Setup(fr => fr.GetExcelFilePath()).Returns(ConfigurationManager.AppSettings["ValidFile"].ToString());
            _blSale = new BLSale(new BLCommon(new DALSale()));
        }
        [Test]
        public void GetSales_ValidFileForApi_ReturnNonEmpty()
        {
            // Arrange
            var controller = new SaleController(_blSale, _blCommon.Object);

            // Act
            var result = controller.GetSales();

            // Assert
            Assert.That(result.Count(), Is.Not.EqualTo(0));
        }
    }
}
