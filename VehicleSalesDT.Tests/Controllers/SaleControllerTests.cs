using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSalesDT.BusinessLogic;
using VehicleSalesDT.BusinessLogic.Shared;
using VehicleSalesDT.DAL;
using System.Configuration;
using VehicleSalesDT.Models;
using VehicleSalesDT.Controllers;
using System.Web.Mvc;
using Moq;

namespace VehicleSalesDT.Tests.Controllers
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
        public void Index_ViewResults_ReturnNotNull()
        {
            // Arrange
            var controller = new SaleController(_blSale, _blCommon.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
