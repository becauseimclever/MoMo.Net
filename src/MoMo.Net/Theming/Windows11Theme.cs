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
                { "MenuBarBackground", new ColorToken("rgba(32, 32, 32, 0.85)", "MenuBarBackground") },
                { "MenuBarText", new ColorToken("rgba(255, 255, 255, 0.95)", "MenuBarText") },

                // Taskbar + Start + Desktop additions (Feature: Windows 11 Taskbar)
                { "TaskbarBackground", new ColorToken("rgba(243, 243, 243, 0.85)", "TaskbarBackground") },
                { "TaskbarBorder", new ColorToken("#e5e5e5", "TaskbarBorder") },
                { "StartButtonBackground", new ColorToken("transparent", "StartButtonBackground") },
                { "StartButtonHoverBackground", new ColorToken("rgba(0, 0, 0, 0.05)", "StartButtonHoverBackground") },
                { "StartButtonActiveBackground", new ColorToken("rgba(0, 0, 0, 0.08)", "StartButtonActiveBackground") },
                { "StartButtonIcon", new ColorToken("#0078d4", "StartButtonIcon") },
                { "DesktopBackground", new ColorToken("linear-gradient(135deg, #667eea 0%, #764ba2 100%)", "DesktopBackground") },
                { "DesktopBackgroundFallback", new ColorToken("#667eea", "DesktopBackgroundFallback") },
            },
            new Dictionary<string, SpacingToken>
            {
                { "Gap2", new SpacingToken("2px", "Gap2") },
                { "Gap4", new SpacingToken("4px", "Gap4") },
                { "Gap8", new SpacingToken("8px", "Gap8") },
                { "Gap12", new SpacingToken("12px", "Gap12") },
                { "Gap16", new SpacingToken("16px", "Gap16") },
                { "Gap24", new SpacingToken("24px", "Gap24") },
                { "MenuBarHeight", new SpacingToken("48px", "MenuBarHeight") },

                // Explicit taskbar/start sizing
                { "TaskbarHeight", new SpacingToken("48px", "TaskbarHeight") },
                { "TaskbarPadding", new SpacingToken("4px 8px", "TaskbarPadding") },
                { "StartButtonSize", new SpacingToken("40px", "StartButtonSize") },
            },
            new Dictionary<string, TypographyToken>
            {
                { "Body", new TypographyToken("Segoe UI Variable", "14px", "400", "Body") },
                { "BodyStrong", new TypographyToken("Segoe UI Variable", "14px", "600", "BodyStrong") },
                { "Caption", new TypographyToken("Segoe UI Variable", "12px", "400", "Caption") },
                { "Heading1", new TypographyToken("Segoe UI Variable", "28px", "600", "Heading1") },
                { "Heading2", new TypographyToken("Segoe UI Variable", "24px", "600", "Heading2") },
                { "Heading3", new TypographyToken("Segoe UI Variable", "20px", "600", "Heading3") },
                { "MenuBarFont", new TypographyToken("Segoe UI Variable", "12px", "400", "MenuBarFont") },
            },
            new Dictionary<string, ShadowToken>
            {
                { "ElevationLow", new ShadowToken("0 1px 2px rgba(0,0,0,0.12)", "ElevationLow") },
                { "ElevationMedium", new ShadowToken("0 2px 4px rgba(0,0,0,0.16)", "ElevationMedium") },
                { "ElevationHigh", new ShadowToken("0 4px 12px rgba(0,0,0,0.20)", "ElevationHigh") },
                { "MenuBarShadow", new ShadowToken("0 2px 8px rgba(0,0,0,0.15)", "MenuBarShadow") },
                { "TaskbarShadow", new ShadowToken("0 -2px 8px rgba(0, 0, 0, 0.12)", "TaskbarShadow") },
            },
            new Dictionary<string, BorderToken>
            {
                { "FocusOutline", new BorderToken("2px", "solid", "#2563EB", "FocusOutline") },
                { "Divider", new BorderToken("1px", "solid", "#E5E5E5", "Divider") },
                { "MenuBarBorder", new BorderToken("0px", "none", "transparent", "MenuBarBorder") },

                // Start button borders (border + radius semantic separation)
                { "StartButtonBorder", new BorderToken("0px", "none", "transparent", "StartButtonBorder") },
                { "StartButtonRadius", new BorderToken("4px", "solid", "transparent", "StartButtonRadius") },
            })
    {
    }
}
