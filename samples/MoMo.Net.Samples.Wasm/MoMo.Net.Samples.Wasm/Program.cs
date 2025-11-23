using MoMo.Net.Samples.Wasm.Client.Pages;
using MoMo.Net.Samples.Wasm.Components;
using MoMo.Net.Theming;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Register MoMo.Net themes and theme manager (for server-side rendering)
builder.Services.AddSingleton<IThemeManager>(sp =>
{
    var defaultTheme = new Windows11Theme();
    var fallbackTheme = new DefaultFallbackTheme();
    return new ThemeManager(defaultTheme, fallbackTheme);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MoMo.Net.Samples.Wasm.Client._Imports).Assembly);

app.Run();
