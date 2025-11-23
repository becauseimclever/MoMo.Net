using System.Text;
#pragma warning disable SA1513 // Closing brace should be followed by blank line (suppressed due to private method layout preference)
using Microsoft.AspNetCore.Components;
using MoMo.Net.Theming;

namespace MoMo.Net.Blazor.Components.Layout;

/// <summary>
/// Windows 11 style taskbar container hosting interactive shell controls.
/// </summary>
public partial class MoMoTaskbar : ComponentBase
{
    /// <summary>Gets or sets an optional theme override; if null, expected via cascading value.</summary>
    [Parameter]
    public ITheme? Theme { get; set; }

    /// <summary>Gets or sets an optional custom CSS class appended to root.</summary>
    [Parameter]
    public string? CssClass { get; set; }

    /// <summary>Gets or sets child content (Start button, pinned items, etc.).</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private string GetCssClasses()
    {
        string classes = "momo-taskbar";
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
        var bg = this.Theme.GetColor("TaskbarBackground");
        if (bg is not null)
        {
            styles.Append("background-color: ").Append(bg.Value).Append("; ");
        }

        var border = this.Theme.GetColor("TaskbarBorder");
        if (border is not null)
        {
            styles.Append("border-top: 1px solid ").Append(border.Value).Append("; ");
        }

        var shadow = this.Theme.GetShadow("TaskbarShadow");
        if (shadow is not null)
        {
            styles.Append("box-shadow: ").Append(shadow.Value).Append("; ");
        }

        var height = this.Theme.GetSpacing("TaskbarHeight");
        if (height is not null)
        {
            styles.Append("height: ").Append(height.Value).Append("; ");
        }

        var padding = this.Theme.GetSpacing("TaskbarPadding");
        if (padding is not null)
        {
            styles.Append("padding: ").Append(padding.Value).Append("; ");
        }

        return styles.ToString();
    }
}
#pragma warning restore SA1513
