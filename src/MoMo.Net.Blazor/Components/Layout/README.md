# MoMoShell Component

The `MoMoShell` component provides a foundational application shell that serves as the baseline container for all UI components. It features a themable menu bar and viewport-sized content container.

## Features

- **Viewport-sized container**: Fills 100% of viewport width and height
- **Flexible menu bar positioning**: Top, Bottom, Left, or Right edge placement
- **Theme system integration**: Fully themable with design tokens
- **Responsive layout**: Content area adjusts automatically based on menu bar position
- **Accessibility**: Proper ARIA landmarks and navigation structure

## Basic Usage

```razor
@page "/"
@using MoMo.Net.Blazor.Components.Layout
@using MoMo.Net.Theming

<MoMoShell Position="MenuBarPosition.Top" Theme="@theme">
    <MenuBarContent>
        <div>File  Edit  View  Help</div>
    </MenuBarContent>
    <ChildContent>
        <h1>Welcome to MoMo.Net</h1>
        <p>Your application content goes here.</p>
    </ChildContent>
</MoMoShell>

@code {
    private ITheme theme = new Windows11Theme();
}
```

## Parameters

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Position` | `MenuBarPosition` | `MenuBarPosition.Top` | Position of the menu bar (Top, Bottom, Left, or Right) |
| `MenuBarContent` | `RenderFragment?` | `null` | Content to display in the menu bar. If null, menu bar is not rendered. |
| `ChildContent` | `RenderFragment?` | `null` | Main content to display in the shell's content area |
| `CssClass` | `string?` | `null` | Optional custom CSS class to apply to the shell container |
| `Theme` | `ITheme?` | `null` | Theme to apply. If null, default browser styling is used. |

## Menu Bar Positions

### Top Position (Default)
```razor
<MoMoShell Position="MenuBarPosition.Top">
    <!-- Menu bar appears at top, content below -->
</MoMoShell>
```

### Bottom Position
```razor
<MoMoShell Position="MenuBarPosition.Bottom">
    <!-- Content at top, menu bar at bottom -->
</MoMoShell>
```

### Left Position
```razor
<MoMoShell Position="MenuBarPosition.Left">
    <!-- Menu bar on left side, content on right -->
</MoMoShell>
```

### Right Position
```razor
<MoMoShell Position="MenuBarPosition.Right">
    <!-- Content on left, menu bar on right side -->
</MoMoShell>
```

## Theming

The shell component supports multiple built-in themes:

### Windows 11 Theme
```csharp
<MoMoShell Theme="@(new Windows11Theme())">
```
- Modern, semi-transparent dark glass effect
- 48px menu bar height
- Backdrop blur effect
- Subtle elevation shadow

### Windows 95 Classic Theme
```csharp
<MoMoShell Theme="@(new Windows95ClassicTheme())">
```
- Solid grey background (#C0C0C0)
- 28px menu bar height
- 3D raised border (outset style)
- Retro appearance

### Default Fallback Theme
```csharp
<MoMoShell Theme="@(new DefaultFallbackTheme())">
```
- Simple, clean appearance
- 40px menu bar height
- Subtle border and shadow

## Accessibility

The component includes proper ARIA attributes:
- Shell menu bar: `role="navigation"` with `aria-label="Main menu"`
- Content area: `role="main"`
- Proper landmark structure for screen readers

## CSS Classes

The component generates the following CSS classes:
- `.momo-shell`: Base shell container
- `.momo-shell-top`: Top position variant
- `.momo-shell-bottom`: Bottom position variant
- `.momo-shell-left`: Left position variant
- `.momo-shell-right`: Right position variant
- `.momo-shell-menubar`: Menu bar container
- `.momo-shell-content`: Content area

## Advanced Example

```razor
<MoMoShell 
    Position="MenuBarPosition.Top" 
    Theme="@currentTheme"
    CssClass="my-custom-shell">
    
    <MenuBarContent>
        <div class="menu-container">
            <button @onclick="ChangeTheme">Switch Theme</button>
            <span>File</span>
            <span>Edit</span>
            <span>View</span>
        </div>
    </MenuBarContent>
    
    <ChildContent>
        <div class="app-content">
            <h1>My Application</h1>
            <p>Content scrolls independently of the menu bar.</p>
        </div>
    </ChildContent>
</MoMoShell>

@code {
    private ITheme currentTheme = new Windows11Theme();
    
    private void ChangeTheme()
    {
        currentTheme = currentTheme is Windows11Theme 
            ? new Windows95ClassicTheme() 
            : new Windows11Theme();
    }
}
```

## Notes

- The shell component fills the entire viewport (100vw × 100vh)
- Content area scrolls independently when content overflows
- Menu bar size is determined by theme tokens
- If `MenuBarContent` is null, only the content area is rendered
- Custom CSS can be applied via the `CssClass` parameter for additional styling
