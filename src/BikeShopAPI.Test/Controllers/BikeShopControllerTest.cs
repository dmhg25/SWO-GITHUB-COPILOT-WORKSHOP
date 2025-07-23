using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using BikeShopAPI.Controllers;
using BikeShopAPI.Entities;
using Xunit;

namespace BikeShopAPI.Test.Controllers
{
    public class BikeShopControllerTest
    {
        private readonly BikeShopController _controller;
        private readonly Mock<ILogger<BikeShopController>> _loggerMock;

        public BikeShopControllerTest()
        {
            _loggerMock = new Mock<ILogger<BikeShopController>>();
            _controller = new BikeShopController(_loggerMock.Object);
        }

        [Fact]
        public void GetAll_ReturnsAllItems()
        {
            var result = _controller.GetAll().Result as OkObjectResult;

            var items = Assert.IsType<List<BikeShop>>(result.Value);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void GetById_ReturnsBikeShop()
        {
            var result = _controller.GetById(1).Result as OkObjectResult;
            Assert.IsType<BikeShop>(result.Value);
        }
        [Fact]
        public void GetById_ReturnsNotFound_ForInvalidId()
        {
            var result = _controller.GetById(-1).Result;
            Assert.IsType<NotFoundResult>(result);
        }
        // Search by name term using SearchByName | Amount of results | Test Description
        // Fast Wheels                            | 1                 | Specific search
        // Wheels                                 | 1                 | General search
        // Fast wheels                            | 1                 | Case insensitive
        // Fast Wheels                            | 1                 | Extra spaces at end
        // Fast  Wheels                           | 1                 | Double space
        [Theory]
        [InlineData("Fast Wheels", 1, "Specific search")]
        [InlineData("Wheels", 1, "General search")]
        [InlineData("Fast wheels", 1, "Case insensitive")]
        [InlineData("Fast Wheels ", 1, "Extra spaces at end")]
        [InlineData("Fast  Wheels", 1, "Double space")]
        public void SearchByName_ReturnsExpectedResults(string searchTerm, int expectedCount, string description)
        {
            var result = _controller.SearchByName(searchTerm).Result as OkObjectResult;
            var items = Assert.IsType<List<BikeShop>>(result.Value);
            Assert.Equal(expectedCount, items.Count);
        }

    }
}
