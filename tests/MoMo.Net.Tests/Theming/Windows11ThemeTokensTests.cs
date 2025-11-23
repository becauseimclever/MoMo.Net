using MoMo.Net.Theming;
using Xunit;

namespace MoMo.Net.Tests.Theming;

public class Windows11ThemeTokensTests
{
    private readonly Windows11Theme _theme = new();

    [Theory]
    [InlineData("TaskbarBackground", "rgba(243, 243, 243, 0.85)")] // Semi-transparent light surface
    [InlineData("TaskbarBorder", "#e5e5e5")] // Subtle divider
    [InlineData("StartButtonBackground", "transparent")] // Rest state
    [InlineData("StartButtonHoverBackground", "rgba(0, 0, 0, 0.05)")] // Hover affordance
    [InlineData("StartButtonActiveBackground", "rgba(0, 0, 0, 0.08)")] // Active/pressed state
    [InlineData("StartButtonIcon", "#0078d4")] // Windows blue
    [InlineData("DesktopBackground", "linear-gradient(135deg, #667eea 0%, #764ba2 100%)")] // Default gradient
    [InlineData("DesktopBackgroundFallback", "#667eea")] // Fallback solid color
    public void ColorTokens_ShouldMatchExpectedValues(string tokenName, string expectedValue)
    {
        var token = this._theme.GetColor(tokenName);
        Assert.NotNull(token); // Fails until token added.
        Assert.Equal(expectedValue, token!.Value);
    }

    [Theory]
    [InlineData("TaskbarHeight", "48px")] // Explicit token for taskbar height
    [InlineData("TaskbarPadding", "4px 8px")] // Horizontal/vertical padding
    [InlineData("StartButtonSize", "40px")] // Square button dimension
    public void SpacingTokens_ShouldMatchExpectedValues(string tokenName, string expectedValue)
    {
        var token = this._theme.GetSpacing(tokenName);
        Assert.NotNull(token);
        Assert.Equal(expectedValue, token!.Value);
    }

    [Fact]
    public void ShadowToken_TaskbarShadow_ShouldExist()
    {
        var token = this._theme.GetShadow("TaskbarShadow");
        Assert.NotNull(token);
        Assert.Equal("0 -2px 8px rgba(0, 0, 0, 0.12)", token!.Value);
    }

    [Theory]
    [InlineData("StartButtonBorder", "0px", "none", "transparent")]
    [InlineData("StartButtonRadius", "4px", "solid", "transparent")]
    public void BorderTokens_ShouldMatchExpectedValues(string tokenName, string width, string style, string color)
    {
        var token = this._theme.GetBorder(tokenName);
        Assert.NotNull(token);
        Assert.Equal(width, token!.Width);
        Assert.Equal(style, token.Style);
        Assert.Equal(color, token.Color);
    }
}
