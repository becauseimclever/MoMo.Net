using System.Collections.Generic;
using MoMo.Net.Tokens;

namespace MoMo.Net.Theming;

/// <summary>
/// Represents a Windows 11 inspired theme variant.
/// </summary>
public sealed class Windows11Theme : BaseTheme
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Windows11Theme"/> class.
    /// </summary>
    public Windows11Theme()
        : base(
            "Windows11",
            new Dictionary<string, ColorToken>
            {
                { "PrimaryBackground", new ColorToken("#F3F3F3", "PrimaryBackground") },
                { "SecondaryBackground", new ColorToken("#FFFFFF", "SecondaryBackground") },
                { "PrimaryText", new ColorToken("#1B1B1B", "PrimaryText") },
                { "SecondaryText", new ColorToken("#2E2E2E", "SecondaryText") },
                { "Accent", new ColorToken("#2563EB", "Accent") },
                { "AccentHover", new ColorToken("#1D4ED8", "AccentHover") },
                { "AccentPressed", new ColorToken("#1E3A8A", "AccentPressed") },
                { "DisabledText", new ColorToken("#8A8A8A", "DisabledText") },
            },
            new Dictionary<string, SpacingToken>
            {
                { "Gap2", new SpacingToken("2px", "Gap2") },
                { "Gap4", new SpacingToken("4px", "Gap4") },
                { "Gap8", new SpacingToken("8px", "Gap8") },
                { "Gap12", new SpacingToken("12px", "Gap12") },
                { "Gap16", new SpacingToken("16px", "Gap16") },
                { "Gap24", new SpacingToken("24px", "Gap24") },
            },
            new Dictionary<string, TypographyToken>
            {
                { "Body", new TypographyToken("Segoe UI Variable", "14px", "400", "Body") },
                { "BodyStrong", new TypographyToken("Segoe UI Variable", "14px", "600", "BodyStrong") },
                { "Caption", new TypographyToken("Segoe UI Variable", "12px", "400", "Caption") },
                { "Heading1", new TypographyToken("Segoe UI Variable", "28px", "600", "Heading1") },
                { "Heading2", new TypographyToken("Segoe UI Variable", "24px", "600", "Heading2") },
                { "Heading3", new TypographyToken("Segoe UI Variable", "20px", "600", "Heading3") },
            },
            new Dictionary<string, ShadowToken>
            {
                { "ElevationLow", new ShadowToken("0 1px 2px rgba(0,0,0,0.12)", "ElevationLow") },
                { "ElevationMedium", new ShadowToken("0 2px 4px rgba(0,0,0,0.16)", "ElevationMedium") },
                { "ElevationHigh", new ShadowToken("0 4px 12px rgba(0,0,0,0.20)", "ElevationHigh") },
            },
            new Dictionary<string, BorderToken>
            {
                { "FocusOutline", new BorderToken("2px", "solid", "#2563EB", "FocusOutline") },
                { "Divider", new BorderToken("1px", "solid", "#E5E5E5", "Divider") },
            })
    {
    }
}
