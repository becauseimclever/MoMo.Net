# MoMo.Net

A themable design system and UI component library for Blazor applications, built with .NET 10 LTS.

## Project Vision

MoMo.Net delivers:
- **Design System**: A comprehensive set of design tokens (colors, spacing, typography) with semantic theming support
- **Blazor Components**: A suite of themable, accessible UI controls for Blazor Server and WebAssembly
- **Accessibility First**: WCAG 2.1 AA compliance with proper ARIA attributes and keyboard navigation
- **Performance Focused**: Optimized for fast rendering and minimal bundle size

## Repository Structure

```
MoMo.Net/
├── src/
│   ├── MoMo.Net/                     # Core library (design tokens, theming engine)
│   │   ├── Tokens/                   # Design token definitions
│   │   ├── Theming/                  # Theme management and resolution
│   │   ├── Components/               # Base component abstractions
│   │   └── Extensions/               # Utility extensions
│   └── MoMo.Net.Blazor/              # Blazor UI components
│       ├── Components/               # Razor components (Button, Card, Modal, etc.)
│       ├── Styling/                  # CSS and design token mapping
│       └── Rendering/                # Render helpers and A11y utilities
├── tests/
│   ├── MoMo.Net.Tests/               # Unit tests (xUnit)
│   └── MoMo.Net.Blazor.Tests/        # Component tests (bUnit + xUnit)
├── docs/
│   ├── planning/                     # Development planning documents
│   ├── architecture/                 # Architecture decision records
│   └── design-system/                # Design system documentation
├── build/                            # Build scripts and CI/CD
├── samples/                          # Sample applications
└── .github/                          # GitHub workflows and settings
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (released November 11, 2025)
- A code editor (Visual Studio 2025, VS Code, or Rider)

### Building the Solution

```powershell
# Restore dependencies
dotnet restore "C:\ws\MoMo.Net\MoMo.Net.sln"

# Build all projects
dotnet build "C:\ws\MoMo.Net\MoMo.Net.sln" --configuration Debug

# Run tests
dotnet test "C:\ws\MoMo.Net\MoMo.Net.sln" --configuration Debug
```

### Project References

The solution includes:
- **MoMo.Net** - Core design system library
- **MoMo.Net.Blazor** - Blazor component library (references MoMo.Net)
- **MoMo.Net.Tests** - Unit tests for core library
- **MoMo.Net.Blazor.Tests** - Component tests with bUnit

## Development Principles

This project follows strict engineering practices:
- **SOLID Principles**: Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion
- **CLEAN Architecture**: Clear separation between Domain, Application, Interface, and Infrastructure layers
- **Test-Driven Development (TDD)**: All features must be accompanied by tests following Red-Green-Refactor
- **DRY (Don't Repeat Yourself)**: Code reuse through abstractions and composition

See [.github/copilot-instructions.md](.github/copilot-instructions.md) for complete development guidelines.

## Architecture

- **Design Tokens**: Immutable value objects representing design primitives
- **Theming**: Layered theme resolution (User Theme → App Default → Fallback)
- **Components**: Composition over inheritance, with centralized styling and A11y helpers
- **Testing**: High coverage goals (~100% for core logic, comprehensive component testing)

## Contributing

This project is in active development. Contributions must adhere to the guidelines in [.github/copilot-instructions.md](.github/copilot-instructions.md).

Key requirements:
- Follow TDD: Write tests first, then implement
- Maintain SOLID and CLEAN principles
- Ensure WCAG 2.1 AA accessibility compliance
- Document all public APIs with XML comments
- Use conventional commits (`feat:`, `fix:`, `refactor:`, etc.)

## Versioning

MoMo.Net follows [Semantic Versioning](https://semver.org/):
- **Current version**: 0.1.0 (pre-release)
- **Target 1.0.0**: After API review and stability milestone

## License

Copyright © 2025 MoMo.Net Contributors

Licensed under the MIT License. See [LICENSE](LICENSE) for details.

## Roadmap

- [x] Repository structure and initial projects
- [ ] Core design token implementation
- [ ] Theme manager and palette builders
- [ ] First Blazor component (Button)
- [ ] Sample application
- [ ] CI/CD pipeline
- [ ] NuGet package publishing

---

For detailed planning and progress tracking, see [docs/planning/](docs/planning/).
