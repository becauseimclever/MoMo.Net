# MoMo.Net Copilot Instructions

These instructions define how AI assistance (GitHub Copilot / Chat) must collaborate on this repository. All generated code must reflect these standards. Deviation requires explicit human approval.

## 1. Project Vision
MoMo.Net is a .NET 10 LTS (latest available LTS) class library delivering:
- A themable design system (design tokens + semantic theming)
- A suite of Blazor-compatible UI controls (server + WebAssembly targets)
- High accessibility (WCAG 2.1 AA) and performance focus

If .NET 10 is not yet GA locally, use the newest installed LTS (verify via `"C:\Program Files\dotnet\dotnet.exe" --info`) but keep code forward-compatible with .NET 10 (no obsolete APIs knowingly introduced).

## 2. High-Level Architecture Principles
- SOLID strictly applied (Single Responsibility; Open for extension/Closed for modification; Liskov; Interface Segregation; Dependency Inversion)
- CLEAN architecture layering:
  - Domain: design tokens, theme contracts, core abstractions
  - Application: services orchestrating theme resolution, component state logic
  - Interface (UI): Razor components, rendering adapters
  - Infrastructure: persistence (if later), configuration providers, resource loaders
- DRY: Reuse via small internal building blocks and extension methods; avoid copy-paste duplication.
- Prefer composition over inheritance for component behaviors.
- Public API surface must be minimal, intentional, and documented.

## 3. Folder & Namespace Structure (Planned)
```
src/
  MoMo.Net/                     -> Root library (core tokens, theming engine)
    Theming/                    -> Theme manager, palette builders
    Tokens/                     -> Design token definitions (color, spacing, typography)
    Components/                 -> Base component abstractions (non-UI)
    Extensions/                 -> Helpful extension methods (guard clauses, etc.)
  MoMo.Net.Blazor/              -> Blazor components (Razor + partial C# classes)
    Components/                 -> Individual UI controls (Button, Card, Modal, etc.)
    Styling/                    -> CSS / SCSS (or generated classes) + design token mapping
    Rendering/                  -> Render fragments, wrappers, A11y helpers
tests/
  MoMo.Net.Tests/               -> Unit tests for core library (xUnit)
  MoMo.Net.Blazor.Tests/        -> Component tests (bUnit + xUnit)
docs/                           -> Architecture, design system reference
build/                          -> CI/CD scripts, packaging specs
```
Namespaces should mirror folders exactly. Avoid generic names like `Utils`; be explicit (`ThemeResolution`, `ColorContrast`).

## 4. Design System & Theming Strategy
- Tokens are immutable value objects (e.g., `ColorToken`, `SpacingToken`).
- Themes are compositions of token sets with semantic roles (e.g., `PrimaryBackground`, `AccentText`).
- Provide a layered resolution order: User Theme > App Default > Fallback.
- Runtime theme switching should be supported without full page reload (Blazor cascading values + event callbacks).
- Support dark/light base themes; extendable via custom palettes.

## 5. Blazor Component Guidelines
- Each component => Razor file (`.razor`) + code-behind partial class (`.razor.cs`).
- Parameters must be validated (null checks, range checks) in `OnParametersSet` or earlier.
- Avoid logic inside Razor markup: move to the code-behind.
- Expose events via `EventCallback` (`EventCallback<T>` preferred for strongly typed data).
- A11y: Always include appropriate ARIA attributes and keyboard interaction patterns (e.g., Space/Enter activation).
- CSS class generation centralized (no scattered string concatenation). Provide helper service.

## 6. Testing Policy (Strict TDD)
Every feature follows Red → Green → Refactor:
1. Write failing test (unit or component).
2. Implement minimal code to pass.
3. Refactor safely (tests remain green).

Testing stack:
- xUnit for unit tests (use built-in `Assert` methods only).
- bUnit for Blazor component tests.
- Optional: Verify library-level contracts with snapshot tests (only if stable and reviewed; avoid flaky snapshots).

**PROHIBITED in tests:**
- FluentAssertions or any third-party assertion libraries. Use xUnit's built-in `Assert` class exclusively.
- Sleeping / timing hacks.
- Reliance on external network or file system (unless explicitly added infra layer with abstractions + test doubles).

Coverage goals:
- Core theming & token logic: ~100% statement/branch.
- Component rendering paths: high coverage of branches & states.
- Public API methods: must have at least one direct test.



## 7. Coding Standards
- C# latest language features allowed if supported by target LTS.
- Use explicit types (avoid `var` except when RHS is obvious or anonymous).
- No magic strings/numbers: centralize in constants or enums.
- Guard clauses at method entry; fail fast with specific exceptions.
- Favor small pure functions over large procedural methods.
- Asynchronous code: use `async`/`await` end-to-end; avoid fire-and-forget unless encapsulated + documented.
- Nullability: enable `<Nullable>enable</Nullable>`; avoid `!` suppressions.
- Logging (if introduced later): structured, no string interpolation for dynamic fields.

## 8. Public API Rules
- Document all public types/members with XML docs (summary + param + returns + remarks if non-trivial).
- Keep surface area lean; internalize helpers.
- Breaking changes require: (a) justification comment in PR, (b) version bump following SemVer.

## 9. NuGet Packaging & Versioning
- Semantic Versioning: MAJOR.MINOR.PATCH.
- Start at `0.x` until first stable milestone; move to `1.0.0` after API review.
- Include SourceLink + deterministic builds.
- Provide README + icon + license metadata in `.csproj`.

## 10. CLI & Tooling Usage
Path Rule (Cross-Platform):
- Commands available on the system `PATH` (e.g., `dotnet`, `git`, `pwsh`, `bash`, `nuget`) MAY be invoked directly without full executable path.
- All repository-relative references (solution, project directories, output paths) MUST use fully qualified absolute paths appropriate to the current OS (Windows: `C:\ws\MoMo.Net\src\MoMo.Net`; Linux/macOS: `/home/dev/ws/MoMo.Net/src/MoMo.Net`).
- Do not rely on implicit working directory; always specify paths explicitly in examples, scripts, and documentation.

Examples (Windows + Linux):
```
dotnet new classlib --name MoMo.Net --framework net10.0 --output "C:\ws\MoMo.Net\src\MoMo.Net"
dotnet new classlib --name MoMo.Net --framework net10.0 --output /home/dev/ws/MoMo.Net/src/MoMo.Net
```
Executable fully qualified (optional, for deterministic CI):
```
"C:\Program Files\dotnet\dotnet.exe" build "C:\ws\MoMo.Net\src\MoMo.Net" /warnaserror
/usr/share/dotnet/dotnet build /home/dev/ws/MoMo.Net/src/MoMo.Net /warnaserror
```

Preferred default: use short form (`dotnet`) unless multiple SDK paths or isolation is required (CI, container, version pinning scenarios).

Scaffold commands:
```
dotnet new classlib --name MoMo.Net --framework net10.0 --output "C:\ws\MoMo.Net\src\MoMo.Net"
dotnet new razorclasslib --name MoMo.Net.Blazor --framework net10.0 --output "C:\ws\MoMo.Net\src\MoMo.Net.Blazor" --support-pages-and-views false
dotnet new xunit --name MoMo.Net.Tests --framework net10.0 --output "C:\ws\MoMo.Net\tests\MoMo.Net.Tests"
dotnet new xunit --name MoMo.Net.Blazor.Tests --framework net10.0 --output "C:\ws\MoMo.Net\tests\MoMo.Net.Blazor.Tests"

dotnet new classlib --name MoMo.Net --framework net10.0 --output /home/dev/ws/MoMo.Net/src/MoMo.Net
dotnet new razorclasslib --name MoMo.Net.Blazor --framework net10.0 --output /home/dev/ws/MoMo.Net/src/MoMo.Net.Blazor --support-pages-and-views false
dotnet new xunit --name MoMo.Net.Tests --framework net10.0 --output /home/dev/ws/MoMo.Net/tests/MoMo.Net.Tests
dotnet new xunit --name MoMo.Net.Blazor.Tests --framework net10.0 --output /home/dev/ws/MoMo.Net/tests/MoMo.Net.Blazor.Tests
```
If `net10.0` not recognized, temporarily use latest LTS (e.g., `net8.0`) but keep this file unchanged—upgrade upon .NET 10 availability.

### Adding Packages
Use the dotnet CLI (package manager) with fully qualified path:
```
"C:\Program Files\dotnet\dotnet.exe" add "C:\ws\MoMo.Net\tests\MoMo.Net.Blazor.Tests" package bunit
```
Do NOT pin versions unless:
- A regression exists in latest.
- A preview feature required and stability proven.
When pinning, justify in PR description.

## 11. Dependency Management
- Keep external dependencies minimal (prefer core BCL & internal abstractions).
- Evaluate footprint on Blazor WebAssembly (bundle size) before adding packages.
- Wrap dependencies behind interfaces for testability (Dependency Inversion).

## 12. Refactoring & DRY Enforcement
- Before duplicating logic, extract to: (a) private method, (b) internal service, (c) extension method.
- Periodically run architectural review (e.g., after each minor version) to consolidate patterns.

## 13. Performance & Accessibility
- Avoid unnecessary re-renders: use `ShouldRender` overrides when beneficial.
- Precompute static token mappings.
- Ensure color contrast >= WCAG AA; provide utility to validate contrast in tests.

## 14. Security Considerations
- No dynamic `RenderFragment` injection from untrusted sources without sanitization.
- Avoid reflection unless absolutely necessary; if used, justify.
- Use safe encoding for any HTML injection points.

## 15. CI/CD (Future)
- Build: restore, build, test, pack.
- Fail build if coverage below threshold (to be defined, e.g., 85%).
- Publish via `dotnet pack` + `dotnet nuget push` (scripted with fully qualified path).

## 16. Commit & PR Conventions
- Conventional Commits: `feat:`, `fix:`, `refactor:`, `test:`, `docs:`, `chore:`.
- PR must include: Purpose, Design Notes, Test Coverage Summary, Potential Follow-ups.
- Include screenshots or HTML diff for visual changes (once UI exists).

## 17. AI Assistant Interaction Rules
- Always respect these instructions before suggesting code.
- For multi-step tasks: propose plan → implement iteratively.
- Never introduce a dependency solely to reduce a few lines of code unless justified (perf, security, maintainability).
- Decline harmful, hateful, racist, sexist, lewd, violent requests: respond with `Sorry, I can't assist with that.`
- Model name disclosure only if user explicitly asks (reply: using GPT-5).
- Provide minimal unrelated commentary—focus on actionable changes.
- Never output license headers unless explicitly requested.

## 18. Review Checklist (Apply Before Merging)
- Tests: All new code covered & pass.
- SOLID: No class with >1 responsibility.
- DRY: No copy-paste duplication in diff.
- Public API: Intentional & documented.
- Exceptions: Specific and meaningful messages.
- Dependencies: Justified in PR.
- Accessibility: ARIA roles/states appropriate.

## 19. Example TDD Flow (Component)
1. Write bUnit test: expect default button renders primary style.
2. Run tests (fail).
3. Implement minimal markup & style mapping.
4. Re-run tests (pass).
5. Refactor: extract style resolver service.
6. Add secondary variant test.

## 20. Future Enhancements (Tracked)
- Add theme editor tooling.
- Provide CSS variable generation pipeline.
- Integrate color contrast auto-fix suggestions.

---
This file governs all AI-assisted contributions. Update only via reviewed PRs.
