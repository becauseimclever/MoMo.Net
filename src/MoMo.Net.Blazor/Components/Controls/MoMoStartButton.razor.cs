using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MoMo.Net.Theming;

namespace MoMo.Net.Blazor.Components.Controls;

/// <summary>
/// Windows 11-style Start button component with keyboard accessibility and theming support.
/// </summary>
public partial class MoMoStartButton : ComponentBase
{
    /// <summary>Gets or sets an optional theme override; if null, expected via cascading value.</summary>
    [Parameter]
    public ITheme? Theme { get; set; }

    /// <summary>Gets or sets an optional custom CSS class appended to root.</summary>
    [Parameter]
    public string? CssClass { get; set; }

    /// <summary>Gets or sets an optional custom ARIA label (default: "Start").</summary>
    [Parameter]
    public string? AriaLabel { get; set; }

    /// <summary>Gets or sets the callback invoked when the Start button is clicked.</summary>
    [Parameter]
    public EventCallback OnClick { get; set; }

    private string GetCssClasses()
    {
        string classes = "momo-start-button";
        if (!string.IsNullOrWhiteSpace(this.CssClass))
        {
            classes += " " + this.CssClass.Trim();
        }

        return classes;
    }

    private string GetInlineStyles()
    {
        if (this.Theme is null)
        {
            return string.Empty;
        }

        var styles = new StringBuilder();

        var background = this.Theme.GetColor("StartButtonBackground");
        if (background is not null)
        {
            styles.Append("background-color: ").Append(background.Value).Append("; ");
        }

        var size = this.Theme.GetSpacing("StartButtonSize");
        if (size is not null)
        {
            styles.Append("width: ").Append(size.Value).Append("; ");
            styles.Append("height: ").Append(size.Value).Append("; ");
        }

        var borderRadius = this.Theme.GetBorder("StartButtonRadius");
        if (borderRadius is not null)
        {
            styles.Append("border-radius: ").Append(borderRadius.Width).Append("; ");
        }

        var border = this.Theme.GetBorder("StartButtonBorder");
        if (border is not null)
        {
            styles.Append("border: ").Append(border.Width).Append(" ").Append(border.Style).Append(" ").Append(border.Color).Append("; ");
        }

        return styles.ToString();
    }

    private string GetIconColor()
    {
        if (this.Theme is null)
        {
            return "#0078d4"; // Default Windows blue
        }

        var iconColor = this.Theme.GetColor("StartButtonIcon");
        return iconColor?.Value ?? "#0078d4";
    }

    private void HandleClick()
    {
        this.OnClick.InvokeAsync();
    }

    private void HandleKeyPress(KeyboardEventArgs e)
    {
        if (e.Key == " " || e.Key == "Enter")
        {
            this.OnClick.InvokeAsync();
        }
    }
}
