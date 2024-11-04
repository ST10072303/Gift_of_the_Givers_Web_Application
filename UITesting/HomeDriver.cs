using Disaster_Alleviation_Foundation.Controllers;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics;

namespace HomeDriver
{
    [TestClass]
    public class HomeControllerUITests
    {
        private HomeController _controller;

        [TestInitialize]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(mockLogger.Object);
        }

        [TestMethod]
        public void Index_Returns_View()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName); // Empty string means it returns the default view
        }

        [TestMethod]
        public void Partners_Returns_View()
        {
            // Act
            var result = _controller.Partners() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName); // Default view
        }

        [TestMethod]
        public void Contact_Returns_View()
        {
            // Act
            var result = _controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName); // Default view
        }

        [TestMethod]
        public void About_Returns_View()
        {
            // Act
            var result = _controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName); // Default view
        }

        [TestMethod]
        public void Error_Returns_View_With_ErrorViewModel()
        {
            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));

            // Check that the RequestId is set in the ErrorViewModel
            var model = result.Model as ErrorViewModel;
            Assert.IsNotNull(model.RequestId);
        }
    }
}
