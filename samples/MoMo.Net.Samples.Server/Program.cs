using MoMo.Net.Samples.Server.Components;
using MoMo.Net.Theming;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register MoMo.Net themes and theme manager
builder.Services.AddSingleton<ITheme>(new Windows11Theme());
builder.Services.AddSingleton<ITheme>(sp => new DefaultFallbackTheme());
builder.Services.AddSingleton<IThemeManager>(sp =>
{
    var defaultTheme = new Windows11Theme();
    var fallbackTheme = new DefaultFallbackTheme();
    return new ThemeManager(defaultTheme, fallbackTheme);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    .AddInteractiveServerRenderMode();

app.Run();
