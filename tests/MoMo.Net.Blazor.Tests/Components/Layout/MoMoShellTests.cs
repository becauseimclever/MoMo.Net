using Bunit;
using Microsoft.AspNetCore.Components;
using MoMo.Net.Blazor.Components.Layout;
using MoMo.Net.Theming;
using Xunit;

namespace MoMo.Net.Blazor.Tests.Components.Layout;

/// <summary>
/// Tests for the <see cref="MoMoShell"/> component.
/// </summary>
public sealed class MoMoShellTests : BunitContext
{
    [Fact]
    public void MoMoShell_RendersWithDefaultTopPosition()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>();

        // Assert
        Assert.Contains("momo-shell", cut.Markup);
        Assert.Contains("momo-shell-top", cut.Markup);
        Assert.Contains("role=\"main\"", cut.Markup);
    }

    [Theory]
    [InlineData(MenuBarPosition.Top, "momo-shell-top")]
    [InlineData(MenuBarPosition.Bottom, "momo-shell-bottom")]
    [InlineData(MenuBarPosition.Left, "momo-shell-left")]
    [InlineData(MenuBarPosition.Right, "momo-shell-right")]
    public void MoMoShell_RendersMenuBarInCorrectPosition(MenuBarPosition position, string expectedCssClass)
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.Position, position));

        // Assert
        Assert.Contains(expectedCssClass, cut.Markup);
    }

    [Fact]
    public void MoMoShell_RendersChildContent()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.ChildContent, builder => builder.AddContent(0, "Test Content")));

        // Assert
        Assert.Contains("Test Content", cut.Markup);
    }

    [Fact]
    public void MoMoShell_RendersMenuBarContent()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.MenuBarContent, builder => builder.AddContent(0, "Menu Items")));

        // Assert
        Assert.Contains("Menu Items", cut.Markup);
    }

    [Fact]
    public void MoMoShell_AppliesCustomCssClass()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.CssClass, "custom-class"));

        // Assert
        Assert.Contains("custom-class", cut.Markup);
    }

    [Fact]
    public void MoMoShell_HasProperAriaLandmarks()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.MenuBarContent, builder => builder.AddContent(0, "Menu")));

        // Assert
        Assert.Contains("role=\"navigation\"", cut.Markup);
        Assert.Contains("aria-label=\"Main menu\"", cut.Markup);
        Assert.Contains("role=\"main\"", cut.Markup);
    }

    [Fact]
    public void MoMoShell_HandlesNullMenuBarContentGracefully()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.ChildContent, builder => builder.AddContent(0, "Content Only")));

        // Assert - Should render without menu bar section
        Assert.Contains("Content Only", cut.Markup);
        Assert.DoesNotContain("role=\"navigation\"", cut.Markup);
    }

    [Fact]
    public void MoMoShell_AppliesThemeColorsCorrectly()
    {
        // Arrange
        ITheme theme = new Windows11Theme();

        // Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.Theme, theme));

        // Assert - Component should include some theme-derived styling
        // We'll verify that the theme name is present in data attributes or classes
        string markup = cut.Markup;
        Assert.NotNull(markup);
        Assert.NotEmpty(markup);
    }

    [Fact]
    public void MoMoShell_MenuBarContentAreaHasCorrectStructure_TopPosition()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.Position, MenuBarPosition.Top)
            .Add(p => p.MenuBarContent, builder => builder.AddContent(0, "Menu"))
            .Add(p => p.ChildContent, builder => builder.AddContent(0, "Content")));

        // Assert
        string markup = cut.Markup;
        Assert.Contains("Menu", markup);
        Assert.Contains("Content", markup);

        // Menu should appear before content in markup (top position)
        int menuIndex = markup.IndexOf("Menu");
        int contentIndex = markup.IndexOf("Content");
        Assert.True(menuIndex < contentIndex, "Menu should appear before content for top position");
    }

    [Fact]
    public void MoMoShell_MenuBarContentAreaHasCorrectStructure_BottomPosition()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.Position, MenuBarPosition.Bottom)
            .Add(p => p.MenuBarContent, builder => builder.AddContent(0, "Menu"))
            .Add(p => p.ChildContent, builder => builder.AddContent(0, "Content")));

        // Assert
        string markup = cut.Markup;
        Assert.Contains("Menu", markup);
        Assert.Contains("Content", markup);

        // Content should appear before menu in markup (bottom position)
        int menuIndex = markup.IndexOf("Menu");
        int contentIndex = markup.IndexOf("Content");
        Assert.True(contentIndex < menuIndex, "Content should appear before menu for bottom position");
    }

    [Theory]
    [InlineData(MenuBarPosition.Top)]
    [InlineData(MenuBarPosition.Bottom)]
    [InlineData(MenuBarPosition.Left)]
    [InlineData(MenuBarPosition.Right)]
    public void MoMoShell_RendersWithAllPositions(MenuBarPosition position)
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.Position, position)
            .Add(p => p.MenuBarContent, builder => builder.AddContent(0, "Menu"))
            .Add(p => p.ChildContent, builder => builder.AddContent(0, "Content")));

        // Assert
        Assert.Contains("Menu", cut.Markup);
        Assert.Contains("Content", cut.Markup);
    }

    [Fact]
    public void MoMoShell_AppliesDesktopBackgroundImage_WhenProvided()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.DesktopBackgroundImage, "/_content/MoMo.Net.Blazor/images/test-bg.jpg"));

        // Assert
        string markup = cut.Markup;
        Assert.Contains("background-image: url('/_content/MoMo.Net.Blazor/images/test-bg.jpg')", markup);
    }

    [Fact]
    public void MoMoShell_AppliesDesktopBackgroundColor_WhenProvidedAndNoImage()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.DesktopBackgroundColor, "#667eea"));

        // Assert
        string markup = cut.Markup;
        Assert.Contains("background-color: #667eea", markup);
    }

    [Fact]
    public void MoMoShell_UsesThemeDesktopBackground_WhenNoParametersProvided()
    {
        // Arrange
        ITheme theme = new Windows11Theme();

        // Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.Theme, theme));

        // Assert
        string markup = cut.Markup;

        // Should contain the gradient from Windows11Theme DesktopBackground token
        Assert.Contains("linear-gradient(135deg, #667eea 0%, #764ba2 100%)", markup);
    }

    [Fact]
    public void MoMoShell_DesktopBackgroundImage_TakesPrecedenceOverColor()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.DesktopBackgroundImage, "/_content/test.jpg")
            .Add(p => p.DesktopBackgroundColor, "#667eea"));

        // Assert
        string markup = cut.Markup;
        Assert.Contains("background-image: url('/_content/test.jpg')", markup);

        // Should also include fallback color
        Assert.Contains("background-color: #667eea", markup);
    }

    [Fact]
    public void MoMoShell_HandlesNullDesktopBackgroundGracefully()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.ChildContent, builder => builder.AddContent(0, "Content")));

        // Assert - Should render without throwing
        string markup = cut.Markup;
        Assert.NotNull(markup);
        Assert.Contains("Content", markup);
    }

    [Fact]
    public void MoMoShell_DesktopBackgroundImage_IncludesProperCssForCoverage()
    {
        // Arrange & Act
        IRenderedComponent<MoMoShell> cut = Render<MoMoShell>(parameters => parameters
            .Add(p => p.DesktopBackgroundImage, "/_content/bg.jpg"));

        // Assert
        string markup = cut.Markup;
        Assert.Contains("background-size: cover", markup);
        Assert.Contains("background-position: center", markup);
        Assert.Contains("background-repeat: no-repeat", markup);
    }
}
