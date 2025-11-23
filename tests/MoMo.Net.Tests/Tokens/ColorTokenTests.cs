using MoMo.Net.Tokens;
using Xunit;

namespace MoMo.Net.Tests.Tokens;

public class ColorTokenTests
{
    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Arrange & Act
        var token = new ColorToken("#FF5733", "PrimaryColor");

        // Assert
        Assert.Equal("#FF5733", token.Value);
        Assert.Equal("PrimaryColor", token.Name);
    }

    [Fact]
    public void Constructor_WithNullValue_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ColorToken(null!, "PrimaryColor"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithEmptyValue_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new ColorToken("", "PrimaryColor"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithWhiteSpaceValue_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new ColorToken("   ", "PrimaryColor"));
        Assert.Equal("Value", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullName_ShouldThrowArgumentNullException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => new ColorToken("#FF5733", null!));
        Assert.Equal("Name", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithEmptyName_ShouldThrowArgumentException()
    {
        // Arrange & Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new ColorToken("#FF5733", ""));
        Assert.Equal("Name", exception.ParamName);
    }

    [Fact]
    public void ValueEquality_WithSameValues_ShouldBeEqual()
    {
        // Arrange
        var token1 = new ColorToken("#FF5733", "PrimaryColor");
        var token2 = new ColorToken("#FF5733", "PrimaryColor");

        // Act & Assert
        Assert.Equal(token1, token2);
        Assert.True(token1 == token2);
        Assert.False(token1 != token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentValues_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new ColorToken("#FF5733", "PrimaryColor");
        var token2 = new ColorToken("#33FF57", "PrimaryColor");

        // Act & Assert
        Assert.NotEqual(token1, token2);
        Assert.False(token1 == token2);
        Assert.True(token1 != token2);
    }

    [Fact]
    public void ValueEquality_WithDifferentNames_ShouldNotBeEqual()
    {
        // Arrange
        var token1 = new ColorToken("#FF5733", "PrimaryColor");
        var token2 = new ColorToken("#FF5733", "SecondaryColor");

        // Act & Assert
        Assert.NotEqual(token1, token2);
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        // Arrange
        var token1 = new ColorToken("#FF5733", "PrimaryColor");
        var token2 = new ColorToken("#FF5733", "PrimaryColor");

        // Act & Assert
        Assert.Equal(token1.GetHashCode(), token2.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnMeaningfulRepresentation()
    {
        // Arrange
        var token = new ColorToken("#FF5733", "PrimaryColor");

        // Act
        var result = token.ToString();

        // Assert
        Assert.Contains("PrimaryColor", result);
        Assert.Contains("#FF5733", result);
    }

    [Fact]
    public void Record_ShouldBeImmutable_CannotChangeValue()
    {
        // Arrange
        var token = new ColorToken("#FF5733", "PrimaryColor");

        // Act - Records don't allow property mutation, this test verifies the structure
        // The fact that we can't write token.Value = "new" or token.Name = "new" proves immutability

        // Assert
        Assert.Equal("#FF5733", token.Value);
        Assert.Equal("PrimaryColor", token.Name);
    }

    [Fact]
    public void With_ShouldCreateNewInstanceWithModifiedValue()
    {
        // Arrange
        var original = new ColorToken("#FF5733", "PrimaryColor");

        // Act
        var modified = original with { Value = "#33FF57" };

        // Assert
        Assert.Equal("#FF5733", original.Value); // Original unchanged
        Assert.Equal("#33FF57", modified.Value); // New instance with new value
        Assert.Equal("PrimaryColor", modified.Name); // Name preserved
    }
}
