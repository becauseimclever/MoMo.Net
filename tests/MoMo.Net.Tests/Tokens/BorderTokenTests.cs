using MoMo.Net.Tokens;
using Xunit;

namespace MoMo.Net.Tests.Tokens;

public class BorderTokenTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange & Act
        var token = new BorderToken("1px", "solid", "#000000", "DefaultBorder");

        // Assert
        Assert.Equal("1px", token.Width);
        Assert.Equal("solid", token.Style);
        Assert.Equal("#000000", token.Color);
        Assert.Equal("DefaultBorder", token.Name);
    }

    [Fact]
    public void Constructor_WithNullWidth_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new BorderToken(null!, "solid", "#000000", "DefaultBorder"));
        Assert.Equal("Width", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithEmptyWidth_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new BorderToken("", "solid", "#000000", "DefaultBorder"));
        Assert.Equal("Width", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullStyle_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new BorderToken("1px", null!, "#000000", "DefaultBorder"));
        Assert.Equal("Style", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullColor_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new BorderToken("1px", "solid", null!, "DefaultBorder"));
        Assert.Equal("Color", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new BorderToken("1px", "solid", "#000000", null!));
        Assert.Equal("Name", exception.ParamName);
    }

    [Fact]
    public void ValueEquality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var token1 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");
        var token2 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");

        // Act & Assert
        Assert.Equal(token1, token2);
        Assert.True(token1 == token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentWidth_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");
        var token2 = new BorderToken("2px", "solid", "#000000", "DefaultBorder");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentStyle_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");
        var token2 = new BorderToken("1px", "dashed", "#000000", "DefaultBorder");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentColor_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");
        var token2 = new BorderToken("1px", "solid", "#FFFFFF", "DefaultBorder");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var token1 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");
        var token2 = new BorderToken("1px", "solid", "#000000", "DefaultBorder");

        // Act & Assert
        Assert.Equal(token1.GetHashCode(), token2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnMeaningfulRepresentation()
    {
        // Arrange
        var token = new BorderToken("1px", "solid", "#000000", "DefaultBorder");

        // Act
        var result = token.ToString();

        // Assert
        Assert.Contains("DefaultBorder", result);
        Assert.Contains("1px", result);
    }
}
