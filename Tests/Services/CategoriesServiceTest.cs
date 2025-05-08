using Application.IRepositories;
using Application.IServices;
using Application.Services;
using Domain;
using Moq;
using Shared.DTOs;

namespace Tests;

public class CategoriesServiceTest
{
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;
    private readonly ICategoryService _categoryService;

    public CategoriesServiceTest()
    {
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _categoryService = new CategoryService(_mockCategoryRepository.Object);
    }

    [Fact]
    public async Task AddCategoryAsync_ShouldAddCategoryAndReturnDTO()
    {
        // Arrange
        var categoryDTO = new CategoryDTO
        {
            Name = "Test Category",
            Description = "Test Description"
        };

        _mockCategoryRepository
            .Setup(repo => repo.AddAsync(It.IsAny<Category>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _categoryService.AddCategoryAsync(categoryDTO);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(categoryDTO.Name, result.Name);
        Assert.Equal(categoryDTO.Description, result.Description);
        _mockCategoryRepository.Verify(repo => repo.AddAsync(It.IsAny<Category>()), Times.Once);
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ShouldReturnAllCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
            new Category { CategoryId = "1", Name = "Category 1", Description = "Description 1" },
            new Category { CategoryId = "2", Name = "Category 2", Description = "Description 2" }
        };

        _mockCategoryRepository
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(categories);

        // Act
        var result = await _categoryService.GetAllCategoriesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        _mockCategoryRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ShouldReturnCategoryDTO_WhenCategoryExists()
    {
        // Arrange
        var category = new Category
        {
            CategoryId = "1",
            Name = "Category 1",
            Description = "Description 1"
        };

        _mockCategoryRepository
            .Setup(repo => repo.GetByIdAsync("1"))
            .ReturnsAsync(category);

        // Act
        var result = await _categoryService.GetCategoryByIdAsync("1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(category.CategoryId, result.CategoryId);
        Assert.Equal(category.Name, result.Name);
        Assert.Equal(category.Description, result.Description);
        _mockCategoryRepository.Verify(repo => repo.GetByIdAsync("1"), Times.Once);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ShouldReturnNull_WhenCategoryDoesNotExist()
    {
        // Arrange
        _mockCategoryRepository
            .Setup(repo => repo.GetByIdAsync("1"))
            .ReturnsAsync((Category)null);

        // Act
        var result = await _categoryService.GetCategoryByIdAsync("1");

        // Assert
        Assert.Null(result);
        _mockCategoryRepository.Verify(repo => repo.GetByIdAsync("1"), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldUpdateCategory_WhenCategoryExists()
    {
        // Arrange
        var category = new Category
        {
            CategoryId = "1",
            Name = "Old Name",
            Description = "Old Description"
        };

        var updatedCategoryDTO = new CategoryDTO
        {
            Name = "New Name",
            Description = "New Description"
        };

        _mockCategoryRepository
            .Setup(repo => repo.GetByIdAsync("1"))
            .ReturnsAsync(category);

        _mockCategoryRepository
            .Setup(repo => repo.UpdateAsync(It.IsAny<Category>()))
            .Returns(Task.CompletedTask);

        // Act
        await _categoryService.UpdateCategoryAsync("1", updatedCategoryDTO);

        // Assert
        _mockCategoryRepository.Verify(repo => repo.GetByIdAsync("1"), Times.Once);
        _mockCategoryRepository.Verify(repo => repo.UpdateAsync(It.Is<Category>(c =>
            c.Name == updatedCategoryDTO.Name && c.Description == updatedCategoryDTO.Description)), Times.Once);
    }

    [Fact]
    public async Task DeleteCategoryAsync_ShouldDeleteCategory_WhenCategoryExists()
    {
        // Arrange
        var category = new Category
        {
            CategoryId = "1",
            Name = "Category 1",
            Description = "Description 1"
        };

        _mockCategoryRepository
            .Setup(repo => repo.GetByIdAsync("1"))
            .ReturnsAsync(category);

        _mockCategoryRepository
            .Setup(repo => repo.DeleteAsync("1"))
            .Returns(Task.CompletedTask);

        // Act
        await _categoryService.DeleteCategoryAsync("1");

        // Assert
        _mockCategoryRepository.Verify(repo => repo.GetByIdAsync("1"), Times.Once);
        _mockCategoryRepository.Verify(repo => repo.DeleteAsync("1"), Times.Once);
    }
}
