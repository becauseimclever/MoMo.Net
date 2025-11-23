using System;
using System.Collections.Generic;

namespace MoMo.Net.Theming;

/// <summary>
/// Exposes theme registration, lookup, and switching capabilities with a defined fallback chain.
/// </summary>
public interface IThemeManager
{
    /// <summary>
    /// Occurs when the current theme changes.
    /// </summary>
    event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

    /// <summary>
    /// Gets the currently active theme (never null after initialization).
    /// </summary>
    ITheme CurrentTheme { get; }

    /// <summary>
    /// Gets the default application theme (used if user theme not set).
    /// </summary>
    ITheme DefaultTheme { get; }

    /// <summary>
    /// Gets the immutable fallback theme used when a token is missing.
    /// </summary>
    ITheme FallbackTheme { get; }

    /// <summary>
    /// Registers a theme by its logical name.
    /// </summary>
    /// <param name="theme">Theme instance.</param>
    /// <returns>True if added; false if a theme with same name already exists.</returns>
    bool RegisterTheme(ITheme theme);

    /// <summary>
    /// Attempts to switch the current theme to the specified name.
    /// </summary>
    /// <param name="name">Theme name.</param>
    /// <returns>True if switched; otherwise false.</returns>
    bool SetTheme(string name);

    /// <summary>
    /// Gets all registered theme names.
    /// </summary>
    /// <returns>A read-only collection of registered theme names.</returns>
    IReadOnlyCollection<string> GetRegisteredThemeNames();

    /// <summary>
    /// Resolves a theme by name (case-sensitive, ordinal).
    /// </summary>
    /// <param name="name">Theme name.</param>
    /// <returns>The theme if found; otherwise null.</returns>
    ITheme? GetTheme(string name);
}
