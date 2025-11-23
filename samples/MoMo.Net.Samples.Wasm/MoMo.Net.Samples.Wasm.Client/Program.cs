using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoMo.Net.Theming;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register MoMo.Net themes and theme manager (for client-side WebAssembly)
builder.Services.AddSingleton<IThemeManager>(sp =>
{
    var defaultTheme = new Windows11Theme();
    var fallbackTheme = new DefaultFallbackTheme();
    return new ThemeManager(defaultTheme, fallbackTheme);
});

await builder.Build().RunAsync();
