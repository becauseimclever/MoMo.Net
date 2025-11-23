using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoMo.Net.Theming;

/// <summary>
/// Default implementation of <see cref="IThemeManager"/> providing registration and switching capabilities
/// with a fallback chain (User Selection -> Default -> Fallback).
/// </summary>
public sealed class ThemeManager : IThemeManager
{
    private readonly ITheme _defaultTheme;
    private readonly ITheme _fallbackTheme;
    private readonly Dictionary<string, ITheme> _themes = new(StringComparer.Ordinal);
    private ITheme _currentTheme;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeManager"/> class.
    /// </summary>
    /// <param name="defaultTheme">The default application theme.</param>
    /// <param name="fallbackTheme">The immutable fallback theme.</param>
    public ThemeManager(ITheme defaultTheme, ITheme fallbackTheme)
    {
        this._defaultTheme = defaultTheme ?? throw new ArgumentNullException(nameof(defaultTheme));
        this._fallbackTheme = fallbackTheme ?? throw new ArgumentNullException(nameof(fallbackTheme));
        this._currentTheme = this._defaultTheme;
        this.RegisterTheme(this._defaultTheme);
        this.RegisterTheme(this._fallbackTheme); // Accessible for explicit selection if desired.
    }

    /// <inheritdoc />
    public event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

    /// <inheritdoc />
    public ITheme CurrentTheme => this._currentTheme;

    /// <inheritdoc />
    public ITheme DefaultTheme => this._defaultTheme;

    /// <inheritdoc />
    public ITheme FallbackTheme => this._fallbackTheme;

    /// <inheritdoc />
    public bool RegisterTheme(ITheme theme)
    {
        if (theme is null)
        {
            throw new ArgumentNullException(nameof(theme));
        }

        if (string.IsNullOrWhiteSpace(theme.Name))
        {
            throw new ArgumentException("Theme name cannot be empty.", nameof(theme));
        }

        if (this._themes.ContainsKey(theme.Name))
        {
            return false;
        }

        this._themes.Add(theme.Name, theme);
        return true;
    }

    /// <inheritdoc />
    public bool SetTheme(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        if (!this._themes.TryGetValue(name, out var theme))
        {
            return false;
        }

        if (ReferenceEquals(theme, this._currentTheme))
        {
            return false; // No change.
        }

        var old = this._currentTheme;
        this._currentTheme = theme;
        this.OnThemeChanged(old, this._currentTheme);
        return true;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<string> GetRegisteredThemeNames() => new ReadOnlyCollection<string>(new List<string>(this._themes.Keys));

    /// <inheritdoc />
    public ITheme? GetTheme(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        return this._themes.TryGetValue(name, out var value) ? value : null;
    }

    private void OnThemeChanged(ITheme? oldTheme, ITheme newTheme)
    {
        this.ThemeChanged?.Invoke(this, new ThemeChangedEventArgs(oldTheme, newTheme));
    }
}
