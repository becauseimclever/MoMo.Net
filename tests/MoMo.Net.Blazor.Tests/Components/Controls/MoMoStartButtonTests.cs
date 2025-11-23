using Bunit;
using MoMo.Net.Blazor.Components.Controls;
using MoMo.Net.Theming;
using Xunit;

namespace MoMo.Net.Blazor.Tests.Components.Controls;

/// <summary>
/// Unit tests for the MoMoStartButton component.
/// Verifies rendering, events, theming, accessibility, and keyboard interaction.
/// </summary>
public sealed class MoMoStartButtonTests
{
    [Fact]
    public void MoMoStartButton_RendersWithCorrectStructure()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>();

        // Assert
        var button = cut.Find("button");
        Assert.NotNull(button);
        Assert.Contains("momo-start-button", button.ClassName);
    }

    [Fact]
    public void MoMoStartButton_HasProperAriaAttributes()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>();

        // Assert
        var button = cut.Find("button");
        var ariaLabel = button.GetAttribute("aria-label");
        Assert.Equal("Start", ariaLabel);
    }

    [Fact]
    public void MoMoStartButton_CustomAriaLabel_OverridesDefault()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.AriaLabel, "Open Start Menu"));

        // Assert
        var button = cut.Find("button");
        var ariaLabel = button.GetAttribute("aria-label");
        Assert.Equal("Open Start Menu", ariaLabel);
    }

    [Fact]
    public void MoMoStartButton_FiresOnClickEvent_WhenClicked()
    {
        // Arrange
        using var ctx = new BunitContext();
        bool wasClicked = false;
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.OnClick, () => { wasClicked = true; }));

        // Act
        var button = cut.Find("button");
        button.Click();

        // Assert
        Assert.True(wasClicked);
    }

    [Fact]
    public void MoMoStartButton_AppliesCustomCssClass()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.CssClass, "custom-class"));

        // Assert
        var button = cut.Find("button");
        Assert.Contains("custom-class", button.ClassName);
        Assert.Contains("momo-start-button", button.ClassName);
    }

    [Fact]
    public void MoMoStartButton_AppliesThemeTokens_WhenThemeProvided()
    {
        // Arrange
        using var ctx = new BunitContext();
        var theme = new Windows11Theme();
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.Theme, theme));

        // Act
        var button = cut.Find("button");
        var style = button.GetAttribute("style");

        // Assert
        Assert.NotNull(style);
        Assert.Contains("background-color: transparent", style); // StartButtonBackground
    }

    [Fact]
    public void MoMoStartButton_RendersWindowsLogo()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>();

        // Assert
        var button = cut.Find("button");
        var svg = button.QuerySelector("svg");
        Assert.NotNull(svg);
    }

    [Fact]
    public void MoMoStartButton_HandlesKeyboardActivation_Space()
    {
        // Arrange
        using var ctx = new BunitContext();
        bool wasClicked = false;
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.OnClick, () => { wasClicked = true; }));

        // Act
        var button = cut.Find("button");
        button.KeyPress(" ");

        // Assert
        Assert.True(wasClicked);
    }

    [Fact]
    public void MoMoStartButton_HandlesKeyboardActivation_Enter()
    {
        // Arrange
        using var ctx = new BunitContext();
        bool wasClicked = false;
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.OnClick, () => { wasClicked = true; }));

        // Act
        var button = cut.Find("button");
        button.KeyPress("Enter");

        // Assert
        Assert.True(wasClicked);
    }

    [Fact]
    public void MoMoStartButton_DoesNotThrow_WhenOnClickIsNull()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>();

        // Assert - no exception thrown
        var button = cut.Find("button");
        var exception = Record.Exception(() => button.Click());
        Assert.Null(exception);
    }

    [Fact]
    public void MoMoStartButton_HasTabIndex_ForKeyboardNavigation()
    {
        // Arrange & Act
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoStartButton>();

        // Assert
        var button = cut.Find("button");
        var tabIndex = button.GetAttribute("tabindex");

        // Button elements are naturally focusable, so tabindex should be 0 or not explicitly set
        // If not set, it defaults to 0 for button elements
        Assert.True(tabIndex is null || tabIndex == "0");
    }

    [Fact]
    public void MoMoStartButton_AppliesWidthAndHeight_FromThemeTokens()
    {
        // Arrange
        using var ctx = new BunitContext();
        var theme = new Windows11Theme();
        var cut = ctx.Render<MoMoStartButton>(parameters => parameters
            .Add(p => p.Theme, theme));

        // Act
        var button = cut.Find("button");
        var style = button.GetAttribute("style");

        // Assert
        Assert.NotNull(style);
        Assert.Contains("40px", style); // StartButtonSize token value
    }
}
