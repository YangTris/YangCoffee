using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Domain;
using Domain.Enum;
using Moq;
using Shared.DTOs;

namespace Tests;

public class ProductServiceTest
{
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IProductVariantRepository> _productVariantRepositoryMock;
    private readonly Mock<IProductImageRepository> _productImageRepositoryMock;
    private readonly IProductService _productService;

    public ProductServiceTest()
    {
        _productRepositoryMock = new Mock<IProductRepository>();
        _productVariantRepositoryMock = new Mock<IProductVariantRepository>();
        _productImageRepositoryMock = new Mock<IProductImageRepository>();
        _productService = new ProductService(
            _productRepositoryMock.Object,
            _productVariantRepositoryMock.Object,
            _productImageRepositoryMock.Object
        );
    }

    [Fact]
    public async Task AddProductAsync_ShouldAddProductAndReturnDTO()
    {
        // Arrange
        var productDTO = new ProductDTO
        {
            Name = "Test Product",
            Description = "Test Description",
            BasePrice = 100.0m,
            CategoryId = "TestCategory",
            ProductImages = new List<ProductImageDTO>
                {
                    new ProductImageDTO { ImageUrl = "http://example.com/image1.jpg" }
                },
            ProductVariants = new List<ProductVariantDTO>
                {
                    new ProductVariantDTO { Region = Region.Asia, RoastType = RoastType.Medium, Size = Size.Big, Taste = "Sweet", Price = 120.0m }
                }
        };

        _productRepositoryMock
            .Setup(repo => repo.AddProductAsync(It.IsAny<Product>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _productService.AddProductAsync(productDTO);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productDTO.Name, result.Name);
        Assert.Equal(productDTO.Description, result.Description);
        Assert.Equal(productDTO.BasePrice, result.BasePrice);
        _productRepositoryMock.Verify(repo => repo.AddProductAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task GetProductByIdAsync_ShouldReturnProductDTO_WhenProductExists()
    {
        // Arrange
        var productId = "TestProductId";
        var product = new Product
        {
            ProductId = productId,
            Name = "Test Product",
            Description = "Test Description",
            BasePrice = 100.0m,
            CreatedDate = DateTimeOffset.Now,
            UpdatedDate = DateTimeOffset.Now,
            CategoryId = "TestCategory"
        };

        _productRepositoryMock
            .Setup(repo => repo.GetProductByIdAsync(productId))
            .ReturnsAsync(product);

        // Act
        var result = await _productService.GetProductByIdAsync(productId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(productId, result.ProductId);
        Assert.Equal(product.Name, result.Name);
        _productRepositoryMock.Verify(repo => repo.GetProductByIdAsync(productId), Times.Once);
    }

    [Fact]
    public async Task DeleteProductAsync_ShouldThrowException_WhenProductDoesNotExist()
    {
        // Arrange
        var productId = "NonExistentProductId";

        _productRepositoryMock
            .Setup(repo => repo.GetProductByIdAsync(productId))
            .ReturnsAsync((Product)null);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _productService.DeleteProductAsync(productId));
        _productRepositoryMock.Verify(repo => repo.GetProductByIdAsync(productId), Times.Once);
    }

    [Fact]
    public async Task GetAllProductsAsync_ShouldReturnListOfProductDTOs()
    {
        // Arrange
        var products = new List<Product>
            {
                new Product { ProductId = "1", Name = "Product 1", BasePrice = 50.0m },
                new Product { ProductId = "2", Name = "Product 2", BasePrice = 75.0m }
            };

        _productRepositoryMock
            .Setup(repo => repo.GetAllProductsAsync())
            .ReturnsAsync(products);

        // Act
        var result = await _productService.GetAllProductsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        _productRepositoryMock.Verify(repo => repo.GetAllProductsAsync(), Times.Once);
    }
}
