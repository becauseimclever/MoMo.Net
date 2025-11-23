using Microsoft.AspNetCore.Components;
using MoMo.Net.Theming;

namespace MoMo.Net.Blazor.Components.Layout;

/// <summary>
/// Provides a foundational application shell component that serves as the baseline container
/// for all UI components. Features a themable menu bar and viewport-sized content container.
/// </summary>
public partial class MoMoShell : ComponentBase
{
    /// <summary>
    /// Gets or sets the position of the menu bar within the shell.
    /// Default is <see cref="MenuBarPosition.Top"/>.
    /// </summary>
    [Parameter]
    public MenuBarPosition Position { get; set; } = MenuBarPosition.Top;

    /// <summary>
    /// Gets or sets the content to be displayed in the menu bar.
    /// If null, the menu bar is not rendered.
    /// </summary>
    [Parameter]
    public RenderFragment? MenuBarContent { get; set; }

    /// <summary>
    /// Gets or sets the main content to be displayed in the shell's content area.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets an optional custom CSS class to apply to the shell container.
    /// </summary>
    [Parameter]
    public string? CssClass { get; set; }

    /// <summary>
    /// Gets or sets the theme to apply to the shell component.
    /// If null, a default theme will be used.
    /// </summary>
    [Parameter]
    public ITheme? Theme { get; set; }

    /// <summary>
    /// Gets or sets an optional desktop background image URL.
    /// When provided, this will be used as the background for the content area.
    /// </summary>
    [Parameter]
    public string? DesktopBackgroundImage { get; set; }

    /// <summary>
    /// Gets or sets an optional desktop background color.
    /// Used as a fallback when no image is provided or as a background while the image loads.
    /// </summary>
    [Parameter]
    public string? DesktopBackgroundColor { get; set; }

    /// <summary>
    /// Generates the CSS classes for the shell container based on position and custom class.
    /// </summary>
    /// <returns>A space-separated string of CSS classes.</returns>
    private string GetShellCssClasses()
    {
        string positionClass = this.Position switch
        {
            MenuBarPosition.Top => "momo-shell-top",
            MenuBarPosition.Bottom => "momo-shell-bottom",
            MenuBarPosition.Left => "momo-shell-left",
            MenuBarPosition.Right => "momo-shell-right",
            _ => "momo-shell-top",
        };

        string classes = $"momo-shell {positionClass}";

        if (!string.IsNullOrWhiteSpace(this.CssClass))
        {
            classes += $" {this.CssClass}";
        }

        return classes;
    }

    /// <summary>
    /// Generates inline styles for the menu bar based on theme and position.
    /// </summary>
    /// <returns>A CSS style string.</returns>
    private string GetMenuBarStyles()
    {
        if (this.Theme is null)
        {
            return string.Empty;
        }

        System.Text.StringBuilder styles = new System.Text.StringBuilder();

        // Apply theme colors
        MoMo.Net.Tokens.ColorToken? menuBarBg = this.Theme.GetColor("MenuBarBackground");
        if (menuBarBg is not null)
        {
            styles.Append($"background-color: {menuBarBg.Value}; ");
        }

        MoMo.Net.Tokens.ColorToken? menuBarText = this.Theme.GetColor("MenuBarText");
        if (menuBarText is not null)
        {
            styles.Append($"color: {menuBarText.Value}; ");
        }

        // Apply spacing for menu bar height/width
        MoMo.Net.Tokens.SpacingToken? menuBarHeight = this.Theme.GetSpacing("MenuBarHeight");
        if (menuBarHeight is not null)
        {
            if (this.Position == MenuBarPosition.Top || this.Position == MenuBarPosition.Bottom)
            {
                styles.Append($"height: {menuBarHeight.Value}; ");
            }
            else
            {
                styles.Append($"width: {menuBarHeight.Value}; ");
            }
        }

        // Apply typography
        MoMo.Net.Tokens.TypographyToken? menuBarFont = this.Theme.GetTypography("MenuBarFont");
        if (menuBarFont is not null)
        {
            styles.Append($"font-family: {menuBarFont.FontFamily}; ");
            styles.Append($"font-size: {menuBarFont.FontSize}; ");
            styles.Append($"font-weight: {menuBarFont.FontWeight}; ");
        }

        // Apply shadow
        MoMo.Net.Tokens.ShadowToken? menuBarShadow = this.Theme.GetShadow("MenuBarShadow");
        if (menuBarShadow is not null)
        {
            styles.Append($"box-shadow: {menuBarShadow.Value}; ");
        }

        // Apply border
        MoMo.Net.Tokens.BorderToken? menuBarBorder = this.Theme.GetBorder("MenuBarBorder");
        if (menuBarBorder is not null)
        {
            styles.Append($"border: {menuBarBorder.Width} {menuBarBorder.Style} {menuBarBorder.Color}; ");
        }

        return styles.ToString();
    }

    /// <summary>
    /// Generates inline styles for the content area.
    /// </summary>
    /// <returns>A CSS style string.</returns>
    private string GetContentStyles()
    {
        System.Text.StringBuilder styles = new System.Text.StringBuilder();

        // Priority 1: Explicit DesktopBackgroundColor parameter
        // Priority 2: Theme DesktopBackground token
        // Priority 3: Theme PrimaryBackground token
        string? backgroundColor = this.DesktopBackgroundColor;

        if (string.IsNullOrWhiteSpace(backgroundColor) && this.Theme is not null)
        {
            MoMo.Net.Tokens.ColorToken? desktopBg = this.Theme.GetColor("DesktopBackground");
            if (desktopBg is not null)
            {
                backgroundColor = desktopBg.Value;
            }
            else
            {
                MoMo.Net.Tokens.ColorToken? contentBg = this.Theme.GetColor("PrimaryBackground");
                if (contentBg is not null)
                {
                    backgroundColor = contentBg.Value;
                }
            }
        }

        if (!string.IsNullOrWhiteSpace(backgroundColor))
        {
            styles.Append($"background-color: {backgroundColor}; ");
        }

        // Apply desktop background image if provided
        if (!string.IsNullOrWhiteSpace(this.DesktopBackgroundImage))
        {
            styles.Append($"background-image: url('{this.DesktopBackgroundImage}'); ");
            styles.Append("background-size: cover; ");
            styles.Append("background-position: center; ");
            styles.Append("background-repeat: no-repeat; ");
        }

        return styles.ToString();
    }
}
