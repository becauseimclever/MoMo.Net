using System;

namespace MoMo.Net.Theming;

/// <summary>
/// Provides event data for a theme change operation.
/// </summary>
public sealed class ThemeChangedEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThemeChangedEventArgs"/> class.
    /// </summary>
    /// <param name="oldTheme">The theme prior to change (may be null on first assignment).</param>
    /// <param name="newTheme">The new active theme.</param>
    public ThemeChangedEventArgs(ITheme? oldTheme, ITheme newTheme)
    {
        this.OldTheme = oldTheme;
        this.NewTheme = newTheme ?? throw new ArgumentNullException(nameof(newTheme));
        this.ChangedAtUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets the previous theme instance, if any.
    /// </summary>
    public ITheme? OldTheme { get; }

    /// <summary>
    /// Gets the new theme instance.
    /// </summary>
    public ITheme NewTheme { get; }

    /// <summary>
    /// Gets the UTC timestamp when the change occurred.
    /// </summary>
    public DateTime ChangedAtUtc { get; }
}
