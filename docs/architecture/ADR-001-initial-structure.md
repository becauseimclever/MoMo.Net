# ADR-001: Initial Repository Structure

**Status:** Accepted  
**Date:** 2025-11-22  
**Deciders:** Project Team

## Context

Starting a new .NET class library project for a themable Blazor design system requires establishing a solid foundation with clear architectural boundaries, maintainable structure, and development standards.

## Decision

We will structure the repository with the following principles:

### 1. Project Organization

Two main library projects:
- **MoMo.Net**: Core design system (tokens, theming engine, abstractions)
- **MoMo.Net.Blazor**: Blazor-specific UI components

Two test projects:
- **MoMo.Net.Tests**: Unit tests using xUnit
- **MoMo.Net.Blazor.Tests**: Component tests using bUnit + xUnit

### 2. Architecture Style

**CLEAN Architecture** with clear layer separation:
- **Domain**: Design tokens, theme contracts, core abstractions (immutable value objects)
- **Application**: Theme resolution services, component state logic
- **Interface**: Razor components, render fragments
- **Infrastructure**: (Future) Persistence, configuration providers

### 3. Development Standards

- **Framework**: .NET 10 LTS (released November 11, 2025)
- **Language**: C# with latest language features, nullable reference types enabled
- **Testing**: Strict TDD - all features must have tests first
- **Code Quality**: TreatWarningsAsErrors=true, enforced via Directory.Build.props
- **Style**: .editorconfig with comprehensive C# coding standards

### 4. Configuration Files

- **Directory.Build.props**: Centralize MSBuild properties, SourceLink configuration, package metadata
- **.editorconfig**: Enforce coding style, naming conventions, nullable annotations
- **.gitignore**: Comprehensive ignore patterns for .NET projects

### 5. Folder Structure

```
src/              → Source projects
tests/            → Test projects
docs/             → Documentation (planning, architecture, design system)
build/            → CI/CD scripts
samples/          → Demo applications
.github/          → GitHub workflows and copilot instructions
```

### 6. Dependency Management

- Minimal external dependencies in core library (prefer BCL)
- bUnit for Blazor component testing
- No assertion libraries beyond xUnit (avoid abstraction over test failures)
- Project references: Blazor → Core, Tests → Source

### 7. NuGet Package Strategy

- Separate packages: `MoMo.Net` and `MoMo.Net.Blazor`
- Semantic versioning starting at 0.1.0
- Embedded symbols with SourceLink for debugging
- Deterministic builds for CI/CD

## Consequences

### Positive

- Clear separation of concerns enables independent evolution of core and UI layers
- CLEAN architecture promotes testability and maintainability
- Centralized configuration reduces duplication across projects
- TDD enforcement ensures high test coverage from day one
- Strong typing and nullable annotations catch errors at compile time

### Negative

- Additional overhead maintaining architectural boundaries
- Strict TDD may slow initial development velocity
- Two packages to maintain and version (though this matches usage patterns)

### Neutral

- Learning curve for contributors unfamiliar with CLEAN architecture
- Need for discipline to maintain standards over time

## Alternatives Considered

### Single Project Structure
Rejected because mixing core abstractions with Blazor-specific code would:
- Create tight coupling to Blazor framework
- Make testing more complex
- Limit reusability of design tokens in non-Blazor contexts

### FluentAssertions Library
Initially considered but rejected because:
- Adds abstraction that can hide underlying test failures
- xUnit's built-in assertions are sufficient and more transparent
- Reduces dependency footprint

### Monorepo with Multiple Solutions
Rejected as premature - current scope doesn't justify the complexity.

## Implementation Notes

Completed 2025-11-22:
- Created all project structures
- Configured MSBuild properties and EditorConfig
- Added project references
- Verified build succeeds with warnings-as-errors
- Documented structure in README.md

## References

- [Clean Architecture (Robert C. Martin)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [.NET 10 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
- [bUnit Documentation](https://bunit.dev/)
- [Semantic Versioning](https://semver.org/)
