# Quick Start Guide for MoMo.Net Samples

## Running the Samples

### Option 1: Blazor Server Sample (Recommended for Quick Demo)

```powershell
dotnet run --project "C:\ws\MoMo.Net\samples\MoMo.Net.Samples.Server\MoMo.Net.Samples.Server.csproj"
```

Then open your browser to the URL shown (typically `https://localhost:5001`)

**What you'll see:**
- Server-side rendered application with the MoMoShell component
- Top-positioned menu bar (Windows 11-style)
- Default theme applied
- Fast initial load with server-side interactivity

### Option 2: Blazor WebAssembly Sample

```powershell
dotnet run --project "C:\ws\MoMo.Net\samples\MoMo.Net.Samples.Wasm\MoMo.Net.Samples.Wasm\MoMo.Net.Samples.Wasm.csproj"
```

Then open your browser to the URL shown (typically `https://localhost:5001`)

**What you'll see:**
- Client-side rendered application running entirely in the browser
- Same MoMoShell component with identical functionality
- Slower initial load (downloads WASM), but extremely responsive afterwards
- No server round-trips after initial load

## What to Try

1. **Explore the Shell**: Notice the application title and menu bar layout
2. **Navigate**: Use the navigation menu to move between pages
3. **Responsive Design**: Resize your browser window to see adaptive behavior
4. **Theme System**: The default theme is applied (Windows 11 style)
5. **Accessibility**: Tab through the interface to experience keyboard navigation

## Next Steps

- Modify `MainLayout.razor` to try different `MenuPosition` values (`Top`, `Left`, `Right`, `Bottom`)
- Implement theme switching UI to toggle between themes at runtime
- Add custom pages to see how content renders within the MoMoShell
- Explore the source code to understand the component structure

## Development Workflow

For active development, use the watch mode:

```powershell
# Server sample with hot reload
dotnet watch --project "C:\ws\MoMo.Net\samples\MoMo.Net.Samples.Server\MoMo.Net.Samples.Server.csproj"

# WebAssembly sample with hot reload
dotnet watch --project "C:\ws\MoMo.Net\samples\MoMo.Net.Samples.Wasm\MoMo.Net.Samples.Wasm\MoMo.Net.Samples.Wasm.csproj"
```

Changes to the MoMo.Net libraries will automatically rebuild and reload the sample application.
