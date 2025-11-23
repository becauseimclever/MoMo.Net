using MoMo.Net.Tokens;
using Xunit;

namespace MoMo.Net.Tests.Tokens;

public class TypographyTokenTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange & Act
        var token = new TypographyToken("Segoe UI", "14px", "400", "BodyText");

        // Assert
        Assert.Equal("Segoe UI", token.FontFamily);
        Assert.Equal("14px", token.FontSize);
        Assert.Equal("400", token.FontWeight);
        Assert.Equal("BodyText", token.Name);
    }

    [Fact]
    public void Constructor_WithNullFontFamily_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TypographyToken(null!, "14px", "400", "BodyText"));
        Assert.Equal("FontFamily", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithEmptyFontFamily_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new TypographyToken("", "14px", "400", "BodyText"));
        Assert.Equal("FontFamily", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullFontSize_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TypographyToken("Segoe UI", null!, "400", "BodyText"));
        Assert.Equal("FontSize", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullFontWeight_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TypographyToken("Segoe UI", "14px", null!, "BodyText"));
        Assert.Equal("FontWeight", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new TypographyToken("Segoe UI", "14px", "400", null!));
        Assert.Equal("Name", exception.ParamName);
    }

    [Fact]
    public void ValueEquality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var token1 = new TypographyToken("Segoe UI", "14px", "400", "BodyText");
        var token2 = new TypographyToken("Segoe UI", "14px", "400", "BodyText");

        // Act & Assert
        Assert.Equal(token1, token2);
        Assert.True(token1 == token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentFontFamily_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new TypographyToken("Segoe UI", "14px", "400", "BodyText");
        var token2 = new TypographyToken("Arial", "14px", "400", "BodyText");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentFontSize_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new TypographyToken("Segoe UI", "14px", "400", "BodyText");
        var token2 = new TypographyToken("Segoe UI", "16px", "400", "BodyText");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var token1 = new TypographyToken("Segoe UI", "14px", "400", "BodyText");
        var token2 = new TypographyToken("Segoe UI", "14px", "400", "BodyText");

        // Act & Assert
        Assert.Equal(token1.GetHashCode(), token2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnMeaningfulRepresentation()
    {
        // Arrange
        var token = new TypographyToken("Segoe UI", "14px", "400", "BodyText");

        // Act
        var result = token.ToString();

        // Assert
        Assert.Contains("BodyText", result);
        Assert.Contains("Segoe UI", result);
    }
}
