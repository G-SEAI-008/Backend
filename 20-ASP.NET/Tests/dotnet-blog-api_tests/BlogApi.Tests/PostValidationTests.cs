using System.ComponentModel.DataAnnotations;
using BlogApi.Dtos.Posts;

namespace BlogApi.Tests;

public class PostValidationTests
{
    [Fact]
    public void EmptyTitle_IsInvalid()
    {
        // Arrange
        var dto = new CreatePostDto("", "Some Content");
        var results = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            dto,
            new ValidationContext(dto),
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isValid);
    }
    [Fact]
    public void ValidPost_IsValid()
    {
        // Arrange
        var dto = new CreatePostDto("Hello", "My first post");
        var results = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(
            dto,
            new ValidationContext(dto),
            results,
            validateAllProperties: true);


        Assert.True(isValid);
    }
    [Fact]
    public void TitleOver200Characters_IsInvalid()
    {
        // Arrange
        var dto = new CreatePostDto(new string('A', 201), "Some content");
        var results = new List<ValidationResult>();

        // Act
        var isInvalid = Validator.TryValidateObject(
            dto,
            new ValidationContext(dto),
            results,
            validateAllProperties: true);

        // Assert
        Assert.False(isInvalid);
    }

}