using MoMo.Net.Tokens;
using Xunit;

namespace MoMo.Net.Tests.Tokens;

public class SpacingTokenTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange & Act
        var token = new SpacingToken("16px", "MediumSpacing");

        // Assert
        Assert.Equal("16px", token.Value);
        Assert.Equal("MediumSpacing", token.Name);
    }

    [Fact]
    public void Constructor_WithNullValue_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new SpacingToken(null!, "MediumSpacing"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithEmptyValue_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new SpacingToken("", "MediumSpacing"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new SpacingToken("16px", null!));
        Assert.Equal("Name", exception.ParamName);
    }

    [Fact]
    public void ValueEquality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var token1 = new SpacingToken("16px", "MediumSpacing");
        var token2 = new SpacingToken("16px", "MediumSpacing");

        // Act & Assert
        Assert.Equal(token1, token2);
        Assert.True(token1 == token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new SpacingToken("16px", "MediumSpacing");
        var token2 = new SpacingToken("32px", "MediumSpacing");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var token1 = new SpacingToken("16px", "MediumSpacing");
        var token2 = new SpacingToken("16px", "MediumSpacing");

        // Act & Assert
        Assert.Equal(token1.GetHashCode(), token2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnMeaningfulRepresentation()
    {
        // Arrange
        var token = new SpacingToken("16px", "MediumSpacing");

        // Act
        var result = token.ToString();

        // Assert
        Assert.Contains("MediumSpacing", result);
        Assert.Contains("16px", result);
    }
}
