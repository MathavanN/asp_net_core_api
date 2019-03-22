using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Supermarket.V1.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Supermarket.UnitTests.V1
{
    public class AboutControllerTests
    {
        [Fact]
        public void Get_ReturnsOkObjectResult()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<AboutController>>();

            var aboutController = new AboutController(mockLogger.Object);

            //Act
            var result = aboutController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
