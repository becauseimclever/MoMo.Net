using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MoMo.Net.Tokens;

namespace MoMo.Net.Theming;

/// <summary>
/// Provides a base implementation of <see cref="ITheme"/> with guarded initialization and dictionary wrapping
/// to ensure immutability of exposed collections.
/// </summary>
public abstract class BaseTheme : ITheme
{
    private readonly ReadOnlyDictionary<string, ColorToken> colors;
    private readonly ReadOnlyDictionary<string, SpacingToken> spacing;
    private readonly ReadOnlyDictionary<string, TypographyToken> typography;
    private readonly ReadOnlyDictionary<string, ShadowToken> shadows;
    private readonly ReadOnlyDictionary<string, BorderToken> borders;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTheme"/> class.
    /// </summary>
    /// <param name="name">Theme name.</param>
    /// <param name="colors">Color tokens keyed by semantic role.</param>
    /// <param name="spacing">Spacing tokens keyed by semantic role.</param>
    /// <param name="typography">Typography tokens keyed by semantic role.</param>
    /// <param name="shadows">Shadow tokens keyed by semantic role.</param>
    /// <param name="borders">Border tokens keyed by semantic role.</param>
    protected BaseTheme(
        string name,
        IDictionary<string, ColorToken> colors,
        IDictionary<string, SpacingToken> spacing,
        IDictionary<string, TypographyToken> typography,
        IDictionary<string, ShadowToken> shadows,
        IDictionary<string, BorderToken> borders)
    {
        this.Name = Validate(name, nameof(name));
        this.colors = new ReadOnlyDictionary<string, ColorToken>(Clone(colors));
        this.spacing = new ReadOnlyDictionary<string, SpacingToken>(Clone(spacing));
        this.typography = new ReadOnlyDictionary<string, TypographyToken>(Clone(typography));
        this.shadows = new ReadOnlyDictionary<string, ShadowToken>(Clone(shadows));
        this.borders = new ReadOnlyDictionary<string, BorderToken>(Clone(borders));
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public IReadOnlyDictionary<string, ColorToken> Colors => this.colors;

    /// <inheritdoc />
    public IReadOnlyDictionary<string, SpacingToken> Spacing => this.spacing;

    /// <inheritdoc />
    public IReadOnlyDictionary<string, TypographyToken> Typography => this.typography;

    /// <inheritdoc />
    public IReadOnlyDictionary<string, ShadowToken> Shadows => this.shadows;

    /// <inheritdoc />
    public IReadOnlyDictionary<string, BorderToken> Borders => this.borders;

    /// <inheritdoc />
    public ColorToken? GetColor(string name) => TryGet(this.colors, name);

    /// <inheritdoc />
    public SpacingToken? GetSpacing(string name) => TryGet(this.spacing, name);

    /// <inheritdoc />
    public TypographyToken? GetTypography(string name) => TryGet(this.typography, name);

    /// <inheritdoc />
    public ShadowToken? GetShadow(string name) => TryGet(this.shadows, name);

    /// <inheritdoc />
    public BorderToken? GetBorder(string name) => TryGet(this.borders, name);

    private static TToken? TryGet<TToken>(IReadOnlyDictionary<string, TToken> source, string key)
        where TToken : class
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return null;
        }

        return source.TryGetValue(key, out var value) ? value : null;
    }

    private static string Validate(string value, string paramName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be empty or whitespace.", paramName);
        }

        return value;
    }

    private static IDictionary<string, T> Clone<T>(IDictionary<string, T> source)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return new Dictionary<string, T>(source, StringComparer.Ordinal);
    }
}
