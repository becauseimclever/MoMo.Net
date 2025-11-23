using Bunit;
using MoMo.Net.Blazor.Components.Layout;
using MoMo.Net.Theming;
using Xunit;

namespace MoMo.Net.Blazor.Tests.Components.Layout;

public class MoMoTaskbarTests
{
    [Fact]
    public void RendersRootNavWithClass()
    {
        using var ctx = new BunitContext();
        var cut = ctx.Render<MoMoTaskbar>();
        var nav = cut.Find("nav.momo-taskbar");
        Assert.NotNull(nav);
        Assert.Equal("navigation", nav.GetAttribute("role"));
        Assert.Equal("Taskbar", nav.GetAttribute("aria-label"));
    }

    [Fact]
    public void AppliesThemeBackgroundToken()
    {
        using var ctx = new BunitContext();
        var theme = new Windows11Theme();
        var cut = ctx.Render<MoMoTaskbar>(parameters => parameters.Add(p => p.Theme, theme));
        var nav = cut.Find("nav.momo-taskbar");
        string style = nav.GetAttribute("style") ?? string.Empty;
        Assert.Contains("rgba(243, 243, 243, 0.85)", style); // TaskbarBackground token value
    }
}
