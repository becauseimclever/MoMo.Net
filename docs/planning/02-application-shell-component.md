# Application Shell Component - Planning Document

**Status:** Planning  
**Created:** 2025-11-22  
**Last Updated:** 2025-11-22

## Objective

Create a foundational application shell component that serves as the baseline container for all other UI components in the MoMo.Net design system. This component will provide a themable menu bar and viewport-sized content container.

## Component Overview

### Name
`MoMoShell` (or `AppShell`)

### Purpose
- Provide a full-viewport container that holds all application content
- Host a themable menu bar that can be positioned on any screen edge
- Serve as the composition root for all other MoMo.Net components
- Establish the visual theme foundation for the entire application

### Key Features
1. **Viewport-sized container** - Fills 100% of viewport width/height
2. **Positionable menu bar** - Top, Bottom, Left, or Right edge placement
3. **Theme system integration** - First component to demonstrate theming
4. **Responsive layout** - Content area adjusts based on menu bar position
5. **Accessibility** - Proper landmarks and navigation structure

---

## Design Requirements

### Menu Bar Positioning
```
┌─────────────────────┐  ┌───┬─────────────┐  ┌─────────────────────┐  ┌─────────────────┬───┐
│    Menu Bar (Top)   │  │ M │             │  │                     │  │                 │ M │
├─────────────────────┤  │ e │   Content   │  │      Content        │  │     Content     │ e │
│                     │  │ n │             │  │                     │  │                 │ n │
│      Content        │  │ u │             │  ├─────────────────────┤  │                 │ u │
│                     │  │   │             │  │  Menu Bar (Bottom)  │  │                 │   │
└─────────────────────┘  └───┴─────────────┘  └─────────────────────┘  └─────────────────┴───┘
     Top Position          Left Position          Bottom Position          Right Position
```

### Theme Specifications

#### 1. Windows 11 Theme (Default)
**Visual Style:**
- **Background**: Semi-transparent dark glass effect (`rgba(32, 32, 32, 0.85)`)
- **Border**: None or subtle 1px separator
- **Height/Width**: 48px (horizontal) / 48px (vertical)
- **Blur**: Backdrop blur effect (10px)
- **Shadow**: Subtle elevation shadow
- **Corner Radius**: 0px (flush with edges)
- **Typography**: Segoe UI Variable Display, 12px, weight 400
- **Icons**: Fluent icon style

**Menu Bar Colors:**
- Background: `rgba(32, 32, 32, 0.85)` with backdrop-filter blur
- Text: `rgba(255, 255, 255, 0.95)`
- Hover: `rgba(255, 255, 255, 0.08)`
- Active: `rgba(255, 255, 255, 0.12)`
- Accent: `#0078D4` (Windows Blue)

#### 2. Windows Vista Aero Theme
**Visual Style:**
- **Background**: Glass effect with gradient (`linear-gradient(180deg, rgba(255,255,255,0.9) 0%, rgba(220,230,242,0.9) 100%)`)
- **Border**: 1px solid `rgba(0, 0, 0, 0.1)`
- **Height/Width**: 32px (horizontal) / 32px (vertical)
- **Blur**: Strong backdrop blur (20px)
- **Shadow**: Prominent drop shadow (0 2px 8px rgba(0,0,0,0.3))
- **Corner Radius**: 0px
- **Typography**: Segoe UI, 11px, weight 400
- **Icons**: Vista glossy style

**Menu Bar Colors:**
- Background: Glass gradient with blur
- Text: `#000000`
- Hover: `rgba(255, 255, 255, 0.6)`
- Active: `rgba(255, 255, 255, 0.8)`
- Accent: `#3399FF` (Vista Blue)
- Glow: Outer glow effect on hover

#### 3. Windows 95 Classic Theme
**Visual Style:**
- **Background**: Solid grey (`#C0C0C0`)
- **Border**: 3D raised border (2px outset style)
- **Height/Width**: 28px (horizontal) / 28px (vertical)
- **Blur**: None
- **Shadow**: None (3D borders instead)
- **Corner Radius**: 0px
- **Typography**: MS Sans Serif, 11px, weight 400 (fallback: Arial)
- **Icons**: Pixelated 16x16 style

**Menu Bar Colors:**
- Background: `#C0C0C0` (solid grey)
- Text: `#000000`
- Hover: `#000080` (Navy blue background), `#FFFFFF` (white text)
- Active: `#000080` with dithered pattern
- Border Highlight: `#FFFFFF` (top-left), `#808080` (bottom-right)
- Border Shadow: `#000000` (outer bottom-right)

---

## Technical Architecture

### Design Tokens (MoMo.Net Core)

#### Token Structure
```csharp
// Core token definitions
public record ColorToken(string Value, string Name);
public record SpacingToken(string Value, string Name);
public record TypographyToken(string FontFamily, string FontSize, string FontWeight, string Name);
public record ShadowToken(string Value, string Name);
public record BorderToken(string Width, string Style, string Color, string Name);
```

#### Theme Definition
```csharp
public interface ITheme
{
    string Name { get; }
    ColorToken MenuBarBackground { get; }
    ColorToken MenuBarText { get; }
    ColorToken MenuBarHover { get; }
    ColorToken MenuBarActive { get; }
    ColorToken MenuBarAccent { get; }
    SpacingToken MenuBarHeight { get; }
    TypographyToken MenuBarFont { get; }
    ShadowToken MenuBarShadow { get; }
    BorderToken MenuBarBorder { get; }
    string BackdropFilter { get; }
}
```

### Component Structure (MoMo.Net.Blazor)

#### Files
- `MoMoShell.razor` - Component markup
- `MoMoShell.razor.cs` - Component logic (code-behind)
- `MoMoShellParameters.cs` - Parameter definitions
- `MenuBarPosition.cs` - Enum for positioning
- `MoMoShell.razor.css` - Scoped CSS (if using CSS isolation)

#### Parameters
```csharp
[Parameter] public MenuBarPosition Position { get; set; } = MenuBarPosition.Top;
[Parameter] public RenderFragment? MenuBarContent { get; set; }
[Parameter] public RenderFragment? ChildContent { get; set; }
[Parameter] public string? CssClass { get; set; }
[Parameter] public ITheme? Theme { get; set; }
```

#### MenuBarPosition Enum
```csharp
public enum MenuBarPosition
{
    Top,
    Bottom,
    Left,
    Right
}
```

---

## Implementation Plan (TDD Approach)

### Phase 1: Core Design Tokens
**Location:** `src/MoMo.Net/Tokens/`

#### Step 1.1: Token Value Objects (RED)
- Write tests for token immutability
- Write tests for token validation
- Write tests for token equality

#### Step 1.2: Token Implementation (GREEN)
- Implement `ColorToken` as immutable record
- Implement `SpacingToken` as immutable record
- Implement `TypographyToken` as immutable record
- Implement `ShadowToken` as immutable record
- Implement `BorderToken` as immutable record

#### Step 1.3: Refactor
- Extract common token behavior
- Add XML documentation
- Optimize equality comparisons

---

### Phase 2: Theme System
**Location:** `src/MoMo.Net/Theming/`

#### Step 2.1: Theme Interface (RED)
- Write tests for theme contract
- Write tests for theme immutability
- Write tests for required properties

#### Step 2.2: Theme Implementations (GREEN)
- Implement `Windows11Theme`
- Implement `WindowsVistaAeroTheme`
- Implement `Windows95ClassicTheme`

#### Step 2.3: Theme Manager (RED → GREEN)
- Write tests for theme registration
- Write tests for theme resolution
- Write tests for theme switching
- Implement `ThemeManager` service
- Implement theme provider for Blazor cascading values

---

### Phase 3: Shell Component
**Location:** `src/MoMo.Net.Blazor/Components/`

#### Step 3.1: Component Tests (RED)
**Test file:** `tests/MoMo.Net.Blazor.Tests/Components/MoMoShellTests.cs`

- Test: Shell renders with default top position
- Test: Shell renders menu bar in correct position (all 4 positions)
- Test: Shell renders child content
- Test: Shell renders menu bar content
- Test: Shell applies theme colors correctly
- Test: Shell has proper ARIA landmarks
- Test: Shell calculates content area size correctly based on menu position
- Test: Shell handles null menu bar content gracefully
- Test: Shell applies custom CSS class

#### Step 3.2: Component Implementation (GREEN)
- Implement `MoMoShell.razor` markup
- Implement `MoMoShell.razor.cs` logic
- Implement parameter validation
- Implement CSS generation from theme tokens
- Implement responsive layout calculations

#### Step 3.3: Styling (GREEN)
- Generate CSS classes from theme tokens
- Implement position-specific layouts (flexbox/grid)
- Implement backdrop filters and blur effects
- Implement 3D borders for Classic theme
- Test cross-browser compatibility

#### Step 3.4: Refactor
- Extract CSS class builder service
- Optimize render fragments
- Add comprehensive XML docs
- Verify accessibility with screen reader

---

### Phase 4: Integration & Polish

#### Step 4.1: Sample Application
**Location:** `samples/MoMo.Net.Samples/`

- Create Blazor Server sample app
- Demonstrate all menu positions
- Provide theme switcher
- Show menu bar content examples

#### Step 4.2: Documentation
- Component API documentation
- Theme customization guide
- Usage examples
- Migration guide for positioning

#### Step 4.3: Performance
- Measure render performance
- Optimize CSS generation
- Test with large content trees
- Verify no layout shifts

---

## Accessibility Requirements

### ARIA Landmarks
- Shell container: `role="application"` or no role (main landmark)
- Menu bar: `role="navigation"` with `aria-label="Main menu"`
- Content area: `role="main"`

### Keyboard Navigation
- Tab order: Menu bar → Content
- Focus visible styles on all interactive elements
- Escape key: Close any open menus (future feature)

### Screen Reader
- Announce menu bar position on load
- Proper heading hierarchy in content
- Skip navigation link (future enhancement)

---

## Testing Strategy

### Unit Tests (MoMo.Net.Tests)
- Token validation and immutability
- Theme property correctness
- Theme manager registration and resolution

### Component Tests (MoMo.Net.Blazor.Tests)
- Rendering with all parameter combinations
- CSS class generation
- Theme application
- Layout calculations
- Accessibility attributes

### Manual Testing
- Visual regression across themes
- Browser compatibility (Edge, Chrome, Firefox, Safari)
- Responsive behavior
- Screen reader testing (NVDA, JAWS)

---

## Success Criteria

✅ All token types implemented with tests  
✅ Three themes implemented (Win11, Vista, Win95)  
✅ Shell component renders in all 4 positions  
✅ Theme switching works without layout shift  
✅ WCAG 2.1 AA compliance verified  
✅ Component documentation complete  
✅ Sample app demonstrates all features  
✅ 100% test coverage for core logic  
✅ No build warnings  

---

## Open Questions

1. **CSS Approach**: CSS-in-JS, scoped CSS, or generated stylesheets?
   - **Recommendation**: Generated CSS classes from tokens for performance
   
2. **Theme Loading**: Runtime or compile-time theme selection?
   - **Recommendation**: Runtime with cascading parameter for flexibility

3. **Menu Bar Interactivity**: Should this component handle menu items or just be a container?
   - **Recommendation**: Container only - menu items are separate components

4. **Responsive Behavior**: Should menu bar auto-collapse on mobile?
   - **Recommendation**: No auto-collapse in v1 - let consumers decide

5. **Animation**: Should theme switching be animated?
   - **Recommendation**: No animation in v1 - add in future if needed

---

## Dependencies

- **MoMo.Net**: Token system, theme abstractions
- **MoMo.Net.Blazor**: Component base, rendering helpers
- **bUnit**: Component testing
- **xUnit**: Test framework

---

## Timeline Estimate

- **Phase 1 (Tokens)**: 2-3 days
- **Phase 2 (Theming)**: 3-4 days
- **Phase 3 (Component)**: 4-5 days
- **Phase 4 (Integration)**: 2-3 days
- **Total**: 11-15 days (with TDD rigor)

---

## Next Steps

1. Create detailed task breakdown for Phase 1
2. Set up test project structure matching component structure
3. Begin with ColorToken implementation (TDD)
4. Review and refine theme specifications with stakeholders

---

## Related Documents

- [ADR-001: Initial Repository Structure](../architecture/ADR-001-initial-structure.md)
- [Copilot Instructions](../../.github/copilot-instructions.md)
- TBD: ADR-002: Design Token Architecture
- TBD: ADR-003: Theme System Design
