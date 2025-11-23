using System.Collections.Generic;
using MoMo.Net.Tokens;

namespace MoMo.Net.Theming;

/// <summary>
/// Provides the minimal guaranteed fallback theme used when no other theme supplies a requested token.
/// </summary>
public sealed class DefaultFallbackTheme : BaseTheme
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultFallbackTheme"/> class.
    /// </summary>
    public DefaultFallbackTheme()
        : base(
            "Fallback",
            new Dictionary<string, ColorToken>
            {
                { "PrimaryBackground", new ColorToken("#FFFFFF", "PrimaryBackground") },
                { "PrimaryText", new ColorToken("#000000", "PrimaryText") },
                { "Accent", new ColorToken("#0078D4", "Accent") },
                { "MenuBarBackground", new ColorToken("#F0F0F0", "MenuBarBackground") },
                { "MenuBarText", new ColorToken("#000000", "MenuBarText") },
            },
            new Dictionary<string, SpacingToken>
            {
                { "GapSmall", new SpacingToken("4px", "GapSmall") },
                { "GapMedium", new SpacingToken("8px", "GapMedium") },
                { "GapLarge", new SpacingToken("16px", "GapLarge") },
                { "MenuBarHeight", new SpacingToken("40px", "MenuBarHeight") },
            },
            new Dictionary<string, TypographyToken>
            {
                { "Body", new TypographyToken("Segoe UI", "14px", "400", "Body") },
                { "Heading1", new TypographyToken("Segoe UI", "24px", "600", "Heading1") },
                { "MenuBarFont", new TypographyToken("Segoe UI", "12px", "400", "MenuBarFont") },
            },
            new Dictionary<string, ShadowToken>
            {
                { "ElevationLow", new ShadowToken("0 1px 2px rgba(0,0,0,0.15)", "ElevationLow") },
                { "MenuBarShadow", new ShadowToken("0 1px 3px rgba(0,0,0,0.12)", "MenuBarShadow") },
            },
            new Dictionary<string, BorderToken>
            {
                { "FocusOutline", new BorderToken("2px", "solid", "#0078D4", "FocusOutline") },
                { "MenuBarBorder", new BorderToken("1px", "solid", "#E0E0E0", "MenuBarBorder") },
            })
    {
    }
}
