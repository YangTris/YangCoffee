using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Tests;

public class CategoriesControllerTest
{
    private readonly Mock<ICategoryService> _mockCategoryService;
    private readonly CategoriesController _controller;

    public CategoriesControllerTest()
    {
        _mockCategoryService = new Mock<ICategoryService>();
        _controller = new CategoriesController(_mockCategoryService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfCategories()
    {
        // Arrange
        var categories = new List<CategoryDTO>
            {
                new CategoryDTO { CategoryId = "1", Name = "Category1", Description = "Description1" },
                new CategoryDTO { CategoryId = "2", Name = "Category2", Description = "Description2" }
            };
        _mockCategoryService.Setup(service => service.GetAllCategoriesAsync())
            .ReturnsAsync(categories);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsAssignableFrom<IEnumerable<CategoryDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count());
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WithCategory()
    {
        // Arrange
        var category = new CategoryDTO { CategoryId = "1", Name = "Category1", Description = "Description1" };
        _mockCategoryService.Setup(service => service.GetCategoryByIdAsync("1"))
            .ReturnsAsync(category);

        // Act
        var result = await _controller.GetById("1");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<CategoryDTO>(okResult.Value);
        Assert.Equal("1", returnValue.CategoryId);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        _mockCategoryService.Setup(service => service.GetCategoryByIdAsync("1"))
            .ReturnsAsync((CategoryDTO)null);

        // Act
        var result = await _controller.GetById("1");

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Add_ReturnsCreatedAtActionResult_WithCreatedCategory()
    {
        // Arrange
        var category = new CategoryDTO { CategoryId = "1", Name = "Category1", Description = "Description1" };
        _mockCategoryService.Setup(service => service.AddCategoryAsync(category))
            .ReturnsAsync(category);

        // Act
        var result = await _controller.Add(category);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<CategoryDTO>(createdAtActionResult.Value);
        Assert.Equal("1", returnValue.CategoryId);
    }

    [Fact]
    public async Task Update_ReturnsNoContent_WhenUpdateIsSuccessful()
    {
        // Arrange
        var category = new CategoryDTO { CategoryId = "1", Name = "UpdatedCategory", Description = "UpdatedDescription" };
        _mockCategoryService.Setup(service => service.GetCategoryByIdAsync("1"))
            .ReturnsAsync(category);
        _mockCategoryService.Setup(service => service.UpdateCategoryAsync("1", category))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Update("1", category);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Update_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        _mockCategoryService.Setup(service => service.GetCategoryByIdAsync("1"))
            .ReturnsAsync((CategoryDTO)null);

        // Act
        var result = await _controller.Update("1", new CategoryDTO());

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenDeleteIsSuccessful()
    {
        // Arrange
        var category = new CategoryDTO { CategoryId = "1", Name = "Category1", Description = "Description1" };
        _mockCategoryService.Setup(service => service.GetCategoryByIdAsync("1"))
            .ReturnsAsync(category);
        _mockCategoryService.Setup(service => service.DeleteCategoryAsync("1"))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete("1");

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        _mockCategoryService.Setup(service => service.GetCategoryByIdAsync("1"))
            .ReturnsAsync((CategoryDTO)null);

        // Act
        var result = await _controller.Delete("1");

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
