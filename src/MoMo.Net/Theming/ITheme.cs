using System.Collections.Generic;
using MoMo.Net.Tokens;

namespace MoMo.Net.Theming;

/// <summary>
/// Represents a concrete theme composed of design token sets across categories (color, spacing, typography, shadow, border).
/// Provides semantic accessors for retrieving tokens by their role name.
/// </summary>
public interface ITheme
{
    /// <summary>
    /// Gets the unique theme name (semantic identifier, e.g., "Windows11").
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the color tokens keyed by semantic role name (e.g., "PrimaryBackground").
    /// </summary>
    IReadOnlyDictionary<string, ColorToken> Colors { get; }

    /// <summary>
    /// Gets the spacing tokens keyed by semantic role name (e.g., "GapSmall").
    /// </summary>
    IReadOnlyDictionary<string, SpacingToken> Spacing { get; }

    /// <summary>
    /// Gets the typography tokens keyed by semantic role name (e.g., "BodyText").
    /// </summary>
    IReadOnlyDictionary<string, TypographyToken> Typography { get; }

    /// <summary>
    /// Gets the shadow tokens keyed by semantic role name (e.g., "ElevationLow").
    /// </summary>
    IReadOnlyDictionary<string, ShadowToken> Shadows { get; }

    /// <summary>
    /// Gets the border tokens keyed by semantic role name (e.g., "FocusOutline").
    /// </summary>
    IReadOnlyDictionary<string, BorderToken> Borders { get; }

    /// <summary>
    /// Attempts to retrieve a color token by semantic name.
    /// </summary>
    /// <param name="name">Semantic token name.</param>
    /// <returns>The <see cref="ColorToken"/> if found; otherwise null.</returns>
    ColorToken? GetColor(string name);

    /// <summary>
    /// Attempts to retrieve a spacing token by semantic name.
    /// </summary>
    /// <param name="name">Semantic token name.</param>
    /// <returns>The <see cref="SpacingToken"/> if found; otherwise null.</returns>
    SpacingToken? GetSpacing(string name);

    /// <summary>
    /// Attempts to retrieve a typography token by semantic name.
    /// </summary>
    /// <param name="name">Semantic token name.</param>
    /// <returns>The <see cref="TypographyToken"/> if found; otherwise null.</returns>
    TypographyToken? GetTypography(string name);

    /// <summary>
    /// Attempts to retrieve a shadow token by semantic name.
    /// </summary>
    /// <param name="name">Semantic token name.</param>
    /// <returns>The <see cref="ShadowToken"/> if found; otherwise null.</returns>
    ShadowToken? GetShadow(string name);

    /// <summary>
    /// Attempts to retrieve a border token by semantic name.
    /// </summary>
    /// <param name="name">Semantic token name.</param>
    /// <returns>The <see cref="BorderToken"/> if found; otherwise null.</returns>
    BorderToken? GetBorder(string name);
}
