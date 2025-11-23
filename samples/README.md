# MoMo.Net Sample Applications

This directory contains sample applications demonstrating the MoMo.Net design system and Blazor components in action.

## Assets & Attribution

The desktop wallpaper used in these sample applications is provided by **Smashing Magazine**:
- **Title**: "A Jelly November"
- **Source**: [Monthly Desktop Wallpapers - November 2022](https://www.smashingmagazine.com/2022/10/desktop-wallpaper-calendars-november-2022/)
- **License**: Free for personal and commercial use
- **Credit**: Designed by the Smashing Magazine community

Thank you to Smashing Magazine for publishing beautiful, free wallpapers.

## Available Samples

### 1. MoMo.Net.Samples.Server
A Blazor Server application showcasing the MoMoShell component with server-side interactivity.

**Run the Server sample:**
```powershell
dotnet run --project "C:\ws\MoMo.Net\samples\MoMo.Net.Samples.Server\MoMo.Net.Samples.Server.csproj"
```

Once running, navigate to: `https://localhost:5001` (or the URL displayed in the console)

### 2. MoMo.Net.Samples.Wasm
A Blazor WebAssembly application showcasing the MoMoShell component with client-side interactivity.

**Run the WebAssembly sample:**
```powershell
dotnet run --project "C:\ws\MoMo.Net\samples\MoMo.Net.Samples.Wasm\MoMo.Net.Samples.Wasm\MoMo.Net.Samples.Wasm.csproj"
```

Once running, navigate to: `https://localhost:5001` (or the URL displayed in the console)

## Features Demonstrated

Both samples showcase:
- **MoMoShell Component**: Application shell with configurable menu bar positioning
- **Theme Management**: Runtime theme switching with the ThemeManager service
- **Responsive Layout**: Adaptive layout that works across different screen sizes
- **Accessibility**: WCAG 2.1 AA compliant components with proper ARIA attributes

## Sample Structure

### Server Sample
- Uses server-side rendering with interactive Server components
- Theme state maintained on the server
- Lower initial payload, faster time to interactive

### WebAssembly Sample
- Uses client-side rendering with WebAssembly components
- Theme state maintained in the browser
- Rich client-side interactions without server round-trips
- Hosted architecture (server project + client project)

## Modifying the Samples

Feel free to modify these samples to explore:
- Different menu bar positions (`Top`, `Left`, `Right`, `Bottom`)
- Custom themes (implement `ITheme` interface)
- Additional MoMo.Net components as they are developed
- Integration with your own application code

## Building All Samples

To build both samples at once from the solution:
```powershell
dotnet build "C:\ws\MoMo.Net\MoMo.Net.sln" --configuration Debug
```

## Next Steps

Check out the main [README](../README.md) and [documentation](../docs/) for more information about:
- Creating custom themes
- Building your own components using the design system
- Contributing to MoMo.Net
