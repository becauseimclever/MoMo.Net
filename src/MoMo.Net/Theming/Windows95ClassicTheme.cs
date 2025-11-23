using System.Collections.Generic;
using MoMo.Net.Tokens;

namespace MoMo.Net.Theming;

/// <summary>
/// Represents a Windows 95 classic inspired theme variant for contrast and legacy styling.
/// </summary>
public sealed class Windows95ClassicTheme : BaseTheme
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Windows95ClassicTheme"/> class.
    /// </summary>
    public Windows95ClassicTheme()
        : base(
            "Windows95Classic",
            new Dictionary<string, ColorToken>
            {
                { "PrimaryBackground", new ColorToken("#C0C0C0", "PrimaryBackground") },
                { "SecondaryBackground", new ColorToken("#FFFFFF", "SecondaryBackground") },
                { "PrimaryText", new ColorToken("#000000", "PrimaryText") },
                { "Accent", new ColorToken("#000080", "Accent") },
                { "AccentHover", new ColorToken("#0000A0", "AccentHover") },
                { "MenuBarBackground", new ColorToken("#C0C0C0", "MenuBarBackground") },
                { "MenuBarText", new ColorToken("#000000", "MenuBarText") },
            },
            new Dictionary<string, SpacingToken>
            {
                { "Gap2", new SpacingToken("2px", "Gap2") },
                { "Gap4", new SpacingToken("4px", "Gap4") },
                { "Gap6", new SpacingToken("6px", "Gap6") },
                { "Gap8", new SpacingToken("8px", "Gap8") },
                { "MenuBarHeight", new SpacingToken("28px", "MenuBarHeight") },
            },
            new Dictionary<string, TypographyToken>
            {
                { "Body", new TypographyToken("MS Sans Serif", "13px", "400", "Body") },
                { "Heading1", new TypographyToken("MS Sans Serif", "20px", "600", "Heading1") },
                { "MenuBarFont", new TypographyToken("MS Sans Serif", "11px", "400", "MenuBarFont") },
            },
            new Dictionary<string, ShadowToken>
            {
                { "ElevationLow", new ShadowToken("1px 1px 0 #808080", "ElevationLow") },
                { "MenuBarShadow", new ShadowToken("none", "MenuBarShadow") },
            },
            new Dictionary<string, BorderToken>
            {
                { "FocusOutline", new BorderToken("2px", "solid", "#000080", "FocusOutline") },
                { "WindowBorder", new BorderToken("1px", "solid", "#808080", "WindowBorder") },
                { "MenuBarBorder", new BorderToken("2px", "outset", "#FFFFFF", "MenuBarBorder") },
            })
    {
    }
}
