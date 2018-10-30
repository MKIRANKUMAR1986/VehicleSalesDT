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
    public class MonthSaleControllerTests
    {
        private IBLMonthSale _blBLMonthSale;
        private Mock<IBLCommon> _blCommon;

        [SetUp]
        public void SetUp()
        {
            //Arrange            
            _blCommon = new Mock<IBLCommon>();
            _blCommon.Setup(fr => fr.GetExcelFilePath()).Returns(ConfigurationManager.AppSettings["ValidFile"].ToString());
            _blBLMonthSale = new BLMonthSale(new BLCommon(new DALSale()));
        }

        [Test]
        public void GetMonthSale_ValidFileForApi_ReturnNonEmpty()
        {
            // Arrange
            var controller = new MonthSaleController(_blBLMonthSale, _blCommon.Object);

            // Act
            var result = controller.GetMonthSale();

            // Assert
            Assert.That(result.Count(), Is.Not.EqualTo(0));
        }
    }
}
