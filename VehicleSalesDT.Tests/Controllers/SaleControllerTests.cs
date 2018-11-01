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
using System.IO;
using System.Web;

namespace VehicleSalesDT.Tests.Controllers
{
    [TestFixture]
    public class SaleControllerTests
    {
        private Mock<IBLSale> _blSale;
        private IEnumerable<Sale> _dummySales;

        [SetUp]
        public void SetUp()
        {
            //Arrange            
            _blSale = new Mock<IBLSale>();            
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
        public void Index_ValidSalesList_ReturnNotNull()
        {
            // Arrange
            _blSale.Setup(fr => fr.GetSales(It.IsAny<Stream>())).Returns(_dummySales);
            var controller = new SaleController(_blSale.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_ValidPostedFileButReturnedSalesList_ReturnNotNull()
        {
            // Arrange
            HttpPostedFileBase httpPostedFile = Mock.Of<HttpPostedFileBase>();
            var mock = Mock.Get(httpPostedFile);
            mock.Setup(_ => _.FileName).Returns("fakeFileName.extension");

            using (var memoryStream = new MemoryStream())
            {
                //...populate fake stream
                //setup mock to return stream
                mock.Setup(_ => _.InputStream).Returns(memoryStream);

                _dummySales = null;
                _blSale.Setup(fr => fr.GetSales(It.IsAny<Stream>())).Returns(_dummySales);
                var controller = new SaleController(_blSale.Object);

                // Act
                var result = controller.Index(httpPostedFile);

                // Assert
                Assert.IsNotNull(result);
            }
        }

        [Test]
        public void Index_ValidPostedFileReturnedSalesList_ReturnNotNull()
        {
            // Arrange
            HttpPostedFileBase httpPostedFile = Mock.Of<HttpPostedFileBase>();
            var mock = Mock.Get(httpPostedFile);
            mock.Setup(_ => _.FileName).Returns("fakeFileName.extension");

            using (var memoryStream = new MemoryStream())
            {
                //...populate fake stream
                //setup mock to return stream
                mock.Setup(_ => _.InputStream).Returns(memoryStream);

                _blSale.Setup(fr => fr.GetSales(It.IsAny<Stream>())).Returns(_dummySales);
                var controller = new SaleController(_blSale.Object);

                // Act
                var result = controller.Index(httpPostedFile);

                // Assert
                Assert.IsNotNull(result);
            }
        }
    }
}
