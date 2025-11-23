using MoMo.Net.Tokens;
using Xunit;

namespace MoMo.Net.Tests.Tokens;

public class ShadowTokenTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange & Act
        var token = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");

        // Assert
        Assert.Equal("0 2px 4px rgba(0,0,0,0.2)", token.Value);
        Assert.Equal("ElevationLow", token.Name);
    }

    [Fact]
    public void Constructor_WithNullValue_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ShadowToken(null!, "ElevationLow"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithEmptyValue_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new ShadowToken("", "ElevationLow"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", null!));
        Assert.Equal("Name", exception.ParamName);
    }

    [Fact]
    public void ValueEquality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var token1 = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");
        var token2 = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");

        // Act & Assert
        Assert.Equal(token1, token2);
        Assert.True(token1 == token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");
        var token2 = new ShadowToken("0 4px 8px rgba(0,0,0,0.3)", "ElevationHigh");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var token1 = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");
        var token2 = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");

        // Act & Assert
        Assert.Equal(token1.GetHashCode(), token2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnMeaningfulRepresentation()
    {
        // Arrange
        var token = new ShadowToken("0 2px 4px rgba(0,0,0,0.2)", "ElevationLow");

        // Act
        var result = token.ToString();

        // Assert
        Assert.Contains("ElevationLow", result);
        Assert.Contains("0 2px 4px rgba(0,0,0,0.2)", result);
    }
}
