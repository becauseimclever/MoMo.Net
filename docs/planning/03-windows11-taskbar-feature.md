# Feature Plan: Windows 11 Taskbar & Desktop Background

**Status:** In Progress  
**Target Milestone:** v0.2  
**Started:** 2025-11-23

## Overview

Enhance the MoMoShell component to provide a Windows 11-style user experience with a bottom taskbar, Start button, and desktop background support. This feature will make the Windows 11 theme the default experience and provide the foundation for a familiar desktop metaphor.

## Goals

1. **Windows 11 as Default**: Make Windows 11 theme and bottom taskbar the default configuration
2. **Taskbar Implementation**: Create a fully styled bottom taskbar with proper blur effects, shadows, and spacing
3. **Start Button**: Implement a reusable Start button component matching Windows 11 design language
4. **Desktop Background**: Support theme-based desktop backgrounds in the content area
5. **Accessibility**: Maintain WCAG 2.1 AA compliance throughout
6. **Performance**: Ensure no performance degradation with background rendering

## Requirements

### Functional Requirements

1. **FR-1**: MoMoShell should default to `Position="Bottom"` when using Windows11Theme
2. **FR-2**: Windows11Theme should include design tokens for:
   - Taskbar background (with blur/transparency)
   - Start button colors (normal, hover, active states)
   - Desktop background color/gradient
   - Taskbar shadow and border
3. **FR-3**: A new `MoMoStartButton` component should:
   - Render a Windows 11-style Start button (Windows logo)
   - Support click events via `EventCallback`
   - Include proper ARIA attributes for accessibility
   - Support theming via design tokens
4. **FR-4**: MoMoShell should support a `DesktopBackground` parameter to apply theme-based backgrounds
5. **FR-5**: Sample applications should showcase the Windows 11 taskbar experience

### Non-Functional Requirements

1. **NFR-1**: Taskbar must maintain visual consistency with Windows 11 design language
2. **NFR-2**: Start button must be keyboard accessible (Tab, Space/Enter activation)
3. **NFR-3**: CSS must use modern features (flexbox, CSS custom properties) appropriately
4. **NFR-4**: All new code must follow SOLID principles and DRY
5. **NFR-5**: All new components must have corresponding unit tests (TDD)

### Constraints

1. No external icon libraries (SVG logo inline or CSS-based)
2. Must work in both Server and WebAssembly rendering modes
3. Must not break existing theme switching functionality
4. Desktop background should be optional (graceful fallback)

## Technical Design

### Architecture

```
MoMo.Net/
  Theming/
    Windows11Theme.cs           [MODIFY] Add taskbar & desktop tokens
    
MoMo.Net.Blazor/
  Components/
    Layout/
      MoMoShell.razor           [MODIFY] Add DesktopBackground parameter
      MoMoShell.razor.cs        [MODIFY] Apply desktop background styles
    Controls/
      MoMoStartButton.razor     [NEW] Start button component
      MoMoStartButton.razor.cs  [NEW] Start button logic
  Styling/
    MoMoShell.css               [MODIFY] Add taskbar and desktop styles
    MoMoStartButton.css         [NEW] Start button styles
    
tests/
  MoMo.Net.Blazor.Tests/
    Components/
      Controls/
        MoMoStartButtonTests.cs [NEW] Start button tests
```

### Design Tokens (Windows11Theme)

```csharp
// Taskbar tokens
ColorToken: "TaskbarBackground" => "rgba(243, 243, 243, 0.85)" // Semi-transparent with blur
ColorToken: "TaskbarBorder" => "#e5e5e5"
ShadowToken: "TaskbarShadow" => "0 -2px 8px rgba(0, 0, 0, 0.12)"
SpacingToken: "TaskbarHeight" => "48px"
SpacingToken: "TaskbarPadding" => "4px 8px"

// Start button tokens
ColorToken: "StartButtonBackground" => "transparent"
ColorToken: "StartButtonHoverBackground" => "rgba(0, 0, 0, 0.05)"
ColorToken: "StartButtonActiveBackground" => "rgba(0, 0, 0, 0.08)"
ColorToken: "StartButtonIcon" => "#0078d4" // Windows blue
SpacingToken: "StartButtonSize" => "40px"
BorderToken: "StartButtonBorder" => "none"
BorderToken: "StartButtonRadius" => "4px"

// Desktop background tokens
ColorToken: "DesktopBackground" => "linear-gradient(135deg, #667eea 0%, #764ba2 100%)" // Default gradient
ColorToken: "DesktopBackgroundFallback" => "#667eea"
```

### Component API

#### MoMoStartButton

```razor
<MoMoStartButton OnClick="HandleStartClick" 
                 Theme="@CurrentTheme" 
                 CssClass="my-custom-class" />
```

**Parameters:**
- `OnClick` (EventCallback): Invoked when Start button is clicked
- `Theme` (ITheme?): Optional theme override
- `CssClass` (string?): Optional custom CSS class
- `AriaLabel` (string?): Optional custom aria-label (default: "Start")

#### MoMoShell (Updated)

```razor
<MoMoShell Position="MenuBarPosition.Bottom"
           DesktopBackgroundImage="_content/MoMo.Net.Blazor/images/default-desktop-bg.jpg"
           Theme="@currentTheme">
    <MenuBarContent>
        <MoMoStartButton OnClick="@(() => ShowStartMenu())" />
        <!-- Other taskbar content -->
    </MenuBarContent>
    <ChildContent>
        @Body
    </ChildContent>
</MoMoShell>
```

**New Parameters:**
- `DesktopBackgroundImage` (string?): URL/path to desktop background image (default: null, uses theme color)
- `DesktopBackgroundColor` (string?): Fallback color if image fails to load or is not specified

### CSS Structure

#### Taskbar (Bottom Position)

```css
.momo-shell-bottom {
    display: flex;
    flex-direction: column;
    height: 100vh;
    overflow: hidden;
}

.momo-shell-bottom .momo-menubar {
    order: 2;
    backdrop-filter: blur(30px);
    -webkit-backdrop-filter: blur(30px);
    /* Additional Windows 11 styling */
}

.momo-shell-bottom .momo-content {
    order: 1;
    flex: 1;
    overflow: auto;
}
```

#### Start Button

```css
.momo-start-button {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    width: 40px;
    height: 40px;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.15s ease;
}

.momo-start-button:hover {
    background-color: rgba(0, 0, 0, 0.05);
}

.momo-start-button:active {
    background-color: rgba(0, 0, 0, 0.08);
}

.momo-start-button:focus-visible {
    outline: 2px solid #0078d4;
    outline-offset: 2px;
}
```

## Implementation Plan (TDD Approach)

### Phase 1: Design Tokens & Theme Enhancement
**RED → GREEN → REFACTOR**

1. **Write Tests First**:
   - Test Windows11Theme includes TaskbarBackground token
   - Test Windows11Theme includes StartButton tokens
   - Test Windows11Theme includes DesktopBackground token
   - Test token values match Windows 11 design specs

2. **Implement**: Add tokens to Windows11Theme.cs

3. **Refactor**: Extract common token creation patterns if duplication exists

### Phase 2: MoMoStartButton Component
**RED → GREEN → REFACTOR**

1. **Write Tests First**:
   - Test Start button renders with correct structure
   - Test Start button fires OnClick event when clicked
   - Test Start button applies theme tokens correctly
   - Test Start button has proper ARIA attributes
   - Test Start button keyboard accessibility (Space/Enter)
   - Test Start button applies custom CSS class

2. **Implement**:
   - Create MoMoStartButton.razor with markup
   - Create MoMoStartButton.razor.cs with parameters and logic
   - Create MoMoStartButton.css with Windows 11 styles

3. **Refactor**: Extract common button patterns for future reuse

### Phase 3: MoMoShell Desktop Background
**RED → GREEN → REFACTOR**

1. **Write Tests First**:
   - Test MoMoShell accepts DesktopBackgroundImage parameter
   - Test MoMoShell accepts DesktopBackgroundColor parameter
   - Test MoMoShell applies image background when provided
   - Test MoMoShell applies color background when image not provided
   - Test MoMoShell uses theme token for background fallback
   - Test MoMoShell gracefully handles missing/invalid image URLs

2. **Implement**:
   - Add DesktopBackgroundImage parameter to MoMoShell.razor.cs
   - Add DesktopBackgroundColor parameter to MoMoShell.razor.cs
   - Update GetContentStyles() to apply desktop background (image or color)
   - Update MoMoShell.razor to conditionally apply background
   - Add CSS for background-size, background-position, etc.

3. **Refactor**: Ensure style generation follows DRY principles

### Phase 4: Taskbar Styling Enhancement
**RED → GREEN → REFACTOR**

1. **Write Tests First** (if applicable to CSS):
   - Visual regression tests (optional, document manual verification)
   - Render tests ensuring correct CSS classes applied

2. **Implement**:
   - Enhance MoMoShell.css with taskbar positioning styles
   - Add blur effects and shadows for Windows 11 aesthetic
   - Add responsive considerations for mobile/tablet

3. **Refactor**: Consolidate duplicate CSS rules

### Phase 5: Desktop Wallpaper Asset

1. **Download and Add Wallpaper**:
   - Download wallpaper from Smashing Magazine: https://www.smashingmagazine.com/files/wallpapers/nov-22/a-jelly-november/nocal/nov-22-a-jelly-november-nocal-1920x1080.jpg
   - Add to `src/MoMo.Net.Blazor/wwwroot/images/default-desktop-bg.jpg`
   - Update DesktopBackground implementation to support image URLs
   - Configure as default background in sample applications

2. **Attribution**:
   - Add credit to Smashing Magazine in README.md
   - Include attribution in samples/README.md
   - Document image source in code comments

### Phase 6: Sample Application Updates

1. **Update Both Samples**:
   - Change default Position to Bottom
   - Add MoMoStartButton to MenuBarContent
   - Enable DesktopBackground parameter with wallpaper image
   - Add Start menu placeholder UI (future expansion)

2. **Manual Testing**:
   - Verify visual appearance matches Windows 11
   - Test keyboard navigation
   - Test theme switching
   - Test responsive behavior
   - Verify desktop wallpaper loads and displays correctly

### Phase 7: Documentation & Refinement

1. Create component documentation (README in Components/Controls/)
2. Add code examples to sample apps
3. Update QUICKSTART.md with new features
4. Document design token customization guide
5. Ensure wallpaper attribution is visible and complete

## Success Criteria

- [ ] Windows11Theme includes all taskbar and desktop tokens
- [ ] MoMoStartButton component renders with Windows 11 styling
- [ ] Start button responds to mouse and keyboard interaction
- [ ] MoMoShell supports desktop backgrounds via DesktopBackgroundImage and DesktopBackgroundColor parameters
- [ ] Default desktop wallpaper downloaded and added to wwwroot/images
- [ ] Smashing Magazine attribution properly documented in README and code
- [ ] Taskbar has proper blur, shadow, and positioning (bottom)
- [ ] All new code has ≥90% test coverage
- [ ] Samples showcase Windows 11 taskbar experience with wallpaper
- [ ] Accessibility: WCAG 2.1 AA compliance verified
- [ ] No performance regressions (verified manually)
- [ ] Solution builds without warnings or errors

## Testing Strategy

### Unit Tests (xUnit)

- **Windows11Theme**: Token presence and value validation
- **MoMoStartButton**: Rendering, events, theming, accessibility
- **MoMoShell**: DesktopBackground parameter behavior, style generation

### Component Tests (bUnit)

- **MoMoStartButton**: Full rendering pipeline, event callbacks, theme application
- **MoMoShell**: Integration with Start button, desktop background rendering

### Manual Testing

- Visual comparison with Windows 11 taskbar
- Cross-browser testing (Chrome, Edge, Firefox)
- Responsive testing (desktop, tablet, mobile)
- Keyboard navigation flow
- Theme switching at runtime

## Future Enhancements (Out of Scope)

- Start menu implementation (Phase 4)
- Taskbar icons and pinned apps (Phase 5)
- System tray / notification area (Phase 6)
- Taskbar customization (position override, size, auto-hide) (Phase 7)
- Custom desktop wallpaper images (Phase 8)
- Multiple theme presets (macOS, Windows 95, Ubuntu) (Phase 9)

## Risks & Mitigations

| Risk | Impact | Mitigation |
|------|--------|------------|
| CSS blur effects may not work in all browsers | Medium | Provide fallback background without blur |
| Inline SVG for Windows logo may not scale well | Low | Use CSS-based icon or well-tested SVG |
| Desktop background may cause performance issues | Low | Make it optional, test on low-end devices |
| Bottom taskbar may conflict with browser chrome | Low | Document expected behavior, test in various browsers |

## Dependencies

- Existing MoMoShell component (completed in Phase 2)
- Existing Windows11Theme (completed in Phase 1)
- Existing ThemeManager (completed in Phase 1)

## Assets & Attribution

### Desktop Wallpaper

**Source:** Smashing Magazine - Monthly Desktop Wallpaper (November 2022)  
**Title:** "A Jelly November"  
**URL:** https://www.smashingmagazine.com/files/wallpapers/nov-22/a-jelly-november/nocal/nov-22-a-jelly-november-nocal-1920x1080.jpg  
**Original Article:** https://www.smashingmagazine.com/2022/10/desktop-wallpaper-calendars-november-2022/

**License:** Free for personal and commercial use (as published by Smashing Magazine)  
**Credit:** Wallpaper designed by the Smashing Magazine community. We are grateful to Smashing Magazine for publishing beautiful, free wallpapers for the community.

**Usage in MoMo.Net:**
- Used as the default desktop background in sample applications
- Demonstrates the desktop background feature
- Can be replaced by users with their own images

## References

- Windows 11 Design Guidelines: https://learn.microsoft.com/en-us/windows/apps/design/
- WCAG 2.1 AA: https://www.w3.org/WAI/WCAG21/quickref/
- Copilot Instructions: `.github/copilot-instructions.md`
- Smashing Magazine Wallpapers: https://www.smashingmagazine.com/category/wallpapers/

---

**Last Updated:** 2025-11-23  
**Next Review:** After Phase 2 completion
