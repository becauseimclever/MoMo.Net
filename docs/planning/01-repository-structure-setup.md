# Repository Structure Setup - Action Plan

**Status:** Not Started  
**Created:** 2025-11-22  
**Last Updated:** 2025-11-22

## Objective
Establish the complete repository folder structure and create all initial project files following SOLID, CLEAN architecture, and TDD principles as defined in `copilot-instructions.md`.

## Prerequisites
- .NET 10 SDK installed (or latest LTS if .NET 10 not available)
- Git repository initialized
- `copilot-instructions.md` reviewed and understood

## Repository Structure Overview

```
MoMo.Net/
├── src/
│   ├── MoMo.Net/                     # Core library (tokens, theming engine)
│   └── MoMo.Net.Blazor/              # Blazor UI components
├── tests/
│   ├── MoMo.Net.Tests/               # Unit tests for core library
│   └── MoMo.Net.Blazor.Tests/        # Component tests (bUnit + xUnit)
├── docs/
│   ├── planning/                     # Step-by-step planning documents
│   ├── architecture/                 # Architecture decision records
│   └── design-system/                # Design system documentation
├── build/
│   └── scripts/                      # CI/CD and build automation
├── samples/
│   └── MoMo.Net.Samples/             # Demo Blazor app (future)
├── .github/
│   └── workflows/                    # GitHub Actions (future)
├── .gitignore
├── README.md
├── LICENSE
├── copilot-instructions.md
└── MoMo.Net.sln                      # Solution file
```

## Phase 1: Directory Structure Creation

### Step 1.1: Create Core Directory Structure
Create all primary directories for source, tests, docs, and build.

**Commands (Windows):**
```powershell
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\tests" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\docs\architecture" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\docs\design-system" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\build\scripts" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\samples" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\.github\workflows" -Force
```

**Commands (Linux/macOS):**
```bash
mkdir -p /home/dev/ws/MoMo.Net/src
mkdir -p /home/dev/ws/MoMo.Net/tests
mkdir -p /home/dev/ws/MoMo.Net/docs/architecture
mkdir -p /home/dev/ws/MoMo.Net/docs/design-system
mkdir -p /home/dev/ws/MoMo.Net/build/scripts
mkdir -p /home/dev/ws/MoMo.Net/samples
mkdir -p /home/dev/ws/MoMo.Net/.github/workflows
```

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 2: Core Library Project Setup

### Step 2.1: Create MoMo.Net Core Library
Create the foundational class library for design tokens and theming engine.

**Commands (Windows):**
```powershell
dotnet new classlib --name MoMo.Net --framework net10.0 --output "C:\ws\MoMo.Net\src\MoMo.Net"
```

**Commands (Linux/macOS):**
```bash
dotnet new classlib --name MoMo.Net --framework net10.0 --output /home/dev/ws/MoMo.Net/src/MoMo.Net
```

**Note:** .NET 10 LTS was released on November 11, 2025. Ensure the SDK is installed before proceeding.

**Post-Creation Tasks:**
- [x] Enable nullable reference types in `.csproj`
- [x] Set `<LangVersion>latest</LangVersion>`
- [x] Add project metadata (Author, Description, PackageId, Version `0.1.0`)
- [x] Enable SourceLink and deterministic builds
- [x] Delete default `Class1.cs` file

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

### Step 2.2: Create Subdirectories in MoMo.Net
Establish CLEAN architecture folder structure within core library.

**Commands (Windows):**
```powershell
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net\Tokens" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net\Theming" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net\Components" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net\Extensions" -Force
```

**Commands (Linux/macOS):**
```bash
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net/Tokens
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net/Theming
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net/Components
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net/Extensions
```

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 3: Blazor Library Project Setup

### Step 3.1: Create MoMo.Net.Blazor Razor Class Library
Create the Blazor component library with Razor support.

**Commands (Windows):**
```powershell
dotnet new razorclasslib --name MoMo.Net.Blazor --framework net10.0 --output "C:\ws\MoMo.Net\src\MoMo.Net.Blazor" --support-pages-and-views false
```

**Commands (Linux/macOS):**
```bash
dotnet new razorclasslib --name MoMo.Net.Blazor --framework net10.0 --output /home/dev/ws/MoMo.Net/src/MoMo.Net.Blazor --support-pages-and-views false
```

**Post-Creation Tasks:**
- [x] Enable nullable reference types
- [x] Set `<LangVersion>latest</LangVersion>`
- [x] Add project metadata matching core library
- [x] Add project reference to `MoMo.Net`
- [x] Delete example component files (`Component1.razor`, etc.)
- [x] Delete example static assets if present

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

### Step 3.2: Create Subdirectories in MoMo.Net.Blazor
Establish component organization structure.

**Commands (Windows):**
```powershell
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net.Blazor\Components" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net.Blazor\Styling" -Force
New-Item -ItemType Directory -Path "C:\ws\MoMo.Net\src\MoMo.Net.Blazor\Rendering" -Force
```

**Commands (Linux/macOS):**
```bash
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net.Blazor/Components
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net.Blazor/Styling
mkdir -p /home/dev/ws/MoMo.Net/src/MoMo.Net.Blazor/Rendering
```

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 4: Test Project Setup

### Step 4.1: Create MoMo.Net.Tests Unit Test Project
Create xUnit test project for core library.

**Commands (Windows):**
```powershell
dotnet new xunit --name MoMo.Net.Tests --framework net10.0 --output "C:\ws\MoMo.Net\tests\MoMo.Net.Tests"
```

**Commands (Linux/macOS):**
```bash
dotnet new xunit --name MoMo.Net.Tests --framework net10.0 --output /home/dev/ws/MoMo.Net/tests/MoMo.Net.Tests
```

**Post-Creation Tasks:**
- [x] Enable nullable reference types
- [x] Add project reference to `MoMo.Net`
- [x] Delete default `UnitTest1.cs` file
- [x] Create matching test folder structure (Tokens, Theming, etc.)

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

### Step 4.2: Create MoMo.Net.Blazor.Tests Component Test Project
Create xUnit + bUnit test project for Blazor components.

**Commands (Windows):**
```powershell
dotnet new xunit --name MoMo.Net.Blazor.Tests --framework net10.0 --output "C:\ws\MoMo.Net\tests\MoMo.Net.Blazor.Tests"
```

**Commands (Linux/macOS):**
```bash
dotnet new xunit --name MoMo.Net.Blazor.Tests --framework net10.0 --output /home/dev/ws/MoMo.Net/tests/MoMo.Net.Blazor.Tests
```

**Post-Creation Tasks:**
- [x] Enable nullable reference types
- [x] Add project reference to `MoMo.Net.Blazor`
- [x] Add bUnit package: `dotnet add "C:\ws\MoMo.Net\tests\MoMo.Net.Blazor.Tests" package bunit`
- [x] Delete default `UnitTest1.cs` file
- [x] Create matching test folder structure (Components, Rendering, etc.)

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 5: Solution File Creation

### Step 5.1: Create Solution File and Add Projects
Create a unified solution file to manage all projects.

**Commands (Windows):**
```powershell
dotnet new sln --name MoMo.Net --output "C:\ws\MoMo.Net"
dotnet sln "C:\ws\MoMo.Net\MoMo.Net.sln" add "C:\ws\MoMo.Net\src\MoMo.Net\MoMo.Net.csproj"
dotnet sln "C:\ws\MoMo.Net\MoMo.Net.sln" add "C:\ws\MoMo.Net\src\MoMo.Net.Blazor\MoMo.Net.Blazor.csproj"
dotnet sln "C:\ws\MoMo.Net\MoMo.Net.sln" add "C:\ws\MoMo.Net\tests\MoMo.Net.Tests\MoMo.Net.Tests.csproj"
dotnet sln "C:\ws\MoMo.Net\MoMo.Net.sln" add "C:\ws\MoMo.Net\tests\MoMo.Net.Blazor.Tests\MoMo.Net.Blazor.Tests.csproj"
```

**Commands (Linux/macOS):**
```bash
dotnet new sln --name MoMo.Net --output /home/dev/ws/MoMo.Net
dotnet sln /home/dev/ws/MoMo.Net/MoMo.Net.sln add /home/dev/ws/MoMo.Net/src/MoMo.Net/MoMo.Net.csproj
dotnet sln /home/dev/ws/MoMo.Net/MoMo.Net.sln add /home/dev/ws/MoMo.Net/src/MoMo.Net.Blazor/MoMo.Net.Blazor.csproj
dotnet sln /home/dev/ws/MoMo.Net/MoMo.Net.sln add /home/dev/ws/MoMo.Net/tests/MoMo.Net.Tests/MoMo.Net.Tests.csproj
dotnet sln /home/dev/ws/MoMo.Net/MoMo.Net.sln add /home/dev/ws/MoMo.Net/tests/MoMo.Net.Blazor.Tests/MoMo.Net.Blazor.Tests.csproj
```

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 6: Configuration Files

### Step 6.1: Create/Update .gitignore
Ensure proper .gitignore for .NET projects.

**Tasks:**
- [x] Verify .gitignore includes: `bin/`, `obj/`, `*.user`, `.vs/`, `.vscode/`, `*.suo`, `*.nupkg`
- [x] Add IDE-specific ignores if needed

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

### Step 6.2: Create Directory.Build.props (Optional)
Centralize common MSBuild properties across all projects.

**Location:** `C:\ws\MoMo.Net\Directory.Build.props` (or Linux equivalent)

**Content Example:**
```xml
<Project>
  <PropertyGroup>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <Authors>MoMo.Net Contributors</Authors>
    <Company>MoMo.Net</Company>
    <Copyright>Copyright © 2025 MoMo.Net Contributors</Copyright>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
    <RepositoryUrl>https://github.com/becauseimclever/MoMo.Net</RepositoryUrl>
    <RepositoryType>git</RepositoryType>
    <PublishRepositoryUrl>true</PublishRepositoryUrl>
    <EmbedUntrackedSources>true</EmbedUntrackedSources>
    <DebugType>embedded</DebugType>
    <ContinuousIntegrationBuild Condition="'$(CI)' == 'true'">true</ContinuousIntegrationBuild>
  </PropertyGroup>
</Project>
```

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

### Step 6.3: Create .editorconfig
Enforce C# coding standards.

**Location:** `C:\ws\MoMo.Net\.editorconfig` (or Linux equivalent)

**Tasks:**
- [x] Define indentation (spaces vs tabs)
- [x] Set line ending (LF for cross-platform)
- [x] Configure C# code style rules
- [x] Enable nullable annotations enforcement
- [x] Set naming conventions

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 7: Verification and Initial Build

### Step 7.1: Restore and Build All Projects
Verify all projects compile successfully.

**Commands (Windows):**
```powershell
dotnet restore "C:\ws\MoMo.Net\MoMo.Net.sln"
dotnet build "C:\ws\MoMo.Net\MoMo.Net.sln" --configuration Debug --no-restore
dotnet test "C:\ws\MoMo.Net\MoMo.Net.sln" --configuration Debug --no-build
```

**Commands (Linux/macOS):**
```bash
dotnet restore /home/dev/ws/MoMo.Net/MoMo.Net.sln
dotnet build /home/dev/ws/MoMo.Net/MoMo.Net.sln --configuration Debug --no-restore
dotnet test /home/dev/ws/MoMo.Net/MoMo.Net.sln --configuration Debug --no-build
```

**Expected Results:**
- All projects restore without errors ✓
- All projects build without warnings (TreatWarningsAsErrors=true) ✓
- Test projects run (0 tests initially, expected) ✓

**Actual Results:**
- Restore: Successful (2.4s)
- Build: Successful (14.1s) - All 4 projects compiled without errors or warnings
- Test: Successful (0 tests found, as expected with no test classes yet)

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Phase 8: Documentation Updates

### Step 8.1: Update README.md
Document the repository structure and initial setup instructions.

**Tasks:**
- [x] Add project vision and goals
- [x] Document folder structure
- [x] Add build/test instructions
- [x] Include contribution guidelines reference

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

### Step 8.2: Create Architecture Decision Log
Start documenting architectural decisions.

**Location:** `C:\ws\MoMo.Net\docs\architecture\ADR-001-initial-structure.md`

**Status:** ☐ Not Started | ☐ In Progress | ☑ Completed

**Completion Date:** 2025-11-22

---

## Success Criteria

✅ All phases completed  
✅ Solution builds without warnings  
✅ All test projects run (even with 0 tests)  
✅ Directory structure matches `copilot-instructions.md` specifications  
✅ All projects have nullable enabled and latest C# language version  
✅ Project references correctly established  
✅ NuGet packages (bUnit) installed  
✅ README.md updated with comprehensive project documentation  
✅ Architecture Decision Record (ADR-001) created  

---

## Next Steps
Once this plan is completed:
1. Create action plan for first design token implementation (following TDD)
2. Create action plan for theme manager architecture
3. Create action plan for first Blazor component (Button)

---

## Notes and Issues
*Document any deviations, blockers, or decisions made during execution:*

**Decisions Made:**
1. **FluentAssertions Removed**: Initially added but removed per project guidelines - using only xUnit's built-in assertions to avoid hiding underlying test issues
2. **Directory.Build.props Created**: Centralized common MSBuild properties to reduce duplication across project files
3. **.editorconfig Created**: Comprehensive C# code style rules, naming conventions, and nullable enforcement configured

**No Blockers Encountered**

---

**Plan Completion Date:** 2025-11-22  
**Status:** ✅ COMPLETED  
**All Phases:** 8/8 Complete
