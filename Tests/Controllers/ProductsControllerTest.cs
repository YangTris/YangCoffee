using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shared.DTOs;
using WebAPI.Controllers;

namespace Tests;

public class ProductsControllerTest
{
    private readonly Mock<IProductService> _mockProductService;
    private readonly ProductsController _controller;

    public ProductsControllerTest()
    {
        _mockProductService = new Mock<IProductService>();
        _controller = new ProductsController(_mockProductService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfProducts()
    {
        // Arrange
        var products = new List<ProductDTO>
            {
                new ProductDTO { ProductId = "1", Name = "Product1", BasePrice = 10 },
                new ProductDTO { ProductId = "2", Name = "Product2", BasePrice = 20 }
            };
        _mockProductService.Setup(service => service.GetAllProductsAsync()).ReturnsAsync(products);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<ProductDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count());
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WithProduct()
    {
        // Arrange
        var product = new ProductDTO { ProductId = "1", Name = "Product1", BasePrice = 10 };
        _mockProductService.Setup(service => service.GetProductByIdAsync("1")).ReturnsAsync(product);

        // Act
        var result = await _controller.GetById("1");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<ProductDTO>(okResult.Value);
        Assert.Equal("1", returnValue.ProductId);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        _mockProductService.Setup(service => service.GetProductByIdAsync("1")).ReturnsAsync((ProductDTO)null);

        // Act
        var result = await _controller.GetById("1");

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Add_ReturnsCreatedAtActionResult_WithCreatedProduct()
    {
        // Arrange
        var product = new ProductDTO { ProductId = "1", Name = "Product1", BasePrice = 10 };
        _mockProductService.Setup(service => service.AddProductAsync(product)).ReturnsAsync(product);

        // Act
        var result = await _controller.Add(product);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<ProductDTO>(createdResult.Value);
        Assert.Equal("1", returnValue.ProductId);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenProductIsUpdated()
    {
        // Arrange
        var updateProduct = new UpdateProductDTO { ProductId = "1", Name = "UpdatedProduct", BasePrice = 15 };
        _mockProductService.Setup(service => service.GetProductByIdAsync("1")).ReturnsAsync(new ProductDTO());
        _mockProductService.Setup(service => service.UpdateProductAsync("1", updateProduct)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Update("1", updateProduct);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenProductIsDeleted()
    {
        // Arrange
        _mockProductService.Setup(service => service.GetProductByIdAsync("1")).ReturnsAsync(new ProductDTO());
        _mockProductService.Setup(service => service.DeleteProductAsync("1")).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete("1");

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        _mockProductService.Setup(service => service.GetProductByIdAsync("1")).ReturnsAsync((ProductDTO)null);

        // Act
        var result = await _controller.Delete("1");

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
