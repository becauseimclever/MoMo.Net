using System;
using MoMo.Net.Theming;
using MoMo.Net.Tokens;
using Xunit;

namespace MoMo.Net.Tests.Theming;

public class ThemeManagerTests
{
    [Fact]
    public void RegisterTheme_WithDuplicateName_ShouldReturnFalse()
    {
        var manager = CreateManager();
        var duplicate = new Windows11Theme();
        var result = manager.RegisterTheme(duplicate);
        Assert.False(result);
    }

    [Fact]
    public void SetTheme_WithUnknownName_ShouldReturnFalse()
    {
        var manager = CreateManager();
        var result = manager.SetTheme("DoesNotExist");
        Assert.False(result);
    }

    [Fact]
    public void SetTheme_WithValidName_ShouldSwitchTheme()
    {
        var manager = CreateManager();
        var classic = new Windows95ClassicTheme();
        var registered = manager.RegisterTheme(classic);
        Assert.True(registered);
        var switched = manager.SetTheme(classic.Name);
        Assert.True(switched);
        Assert.Equal(classic.Name, manager.CurrentTheme.Name);
    }

    [Fact]
    public void SetTheme_SameTheme_ShouldReturnFalse()
    {
        var manager = CreateManager();
        var result = manager.SetTheme(manager.CurrentTheme.Name);
        Assert.False(result);
    }

    [Fact]
    public void ThemeChanged_Event_ShouldFireOnSwitch()
    {
        var manager = CreateManager();
        var classic = new Windows95ClassicTheme();
        manager.RegisterTheme(classic);
        ThemeChangedEventArgs? args = null;
        manager.ThemeChanged += (_, e) => args = e;
        var switched = manager.SetTheme(classic.Name);
        Assert.True(switched);
        Assert.NotNull(args);
        Assert.Equal(classic.Name, args!.NewTheme.Name);
        Assert.NotNull(args.OldTheme);
        Assert.NotEqual(args.OldTheme!.Name, args.NewTheme.Name);
    }

    [Fact]
    public void GetTheme_Existing_ShouldReturnInstance()
    {
        var manager = CreateManager();
        var found = manager.GetTheme(manager.DefaultTheme.Name);
        Assert.NotNull(found);
        Assert.Equal(manager.DefaultTheme.Name, found!.Name);
    }

    [Fact]
    public void GetRegisteredThemeNames_ShouldContainDefaultAndFallback()
    {
        var manager = CreateManager();
        var names = manager.GetRegisteredThemeNames();
        Assert.Contains(manager.DefaultTheme.Name, names);
        Assert.Contains(manager.FallbackTheme.Name, names);
    }

    private static ThemeManager CreateManager()
    {
        var defaultTheme = new Windows11Theme();
        var fallbackTheme = new DefaultFallbackTheme();
        return new ThemeManager(defaultTheme, fallbackTheme);
    }
}
