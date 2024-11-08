using HoneyDo.Shared.Interfaces;
using HoneyDo.Web.Components;
using HoneyDo.Web.Services;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//Use Blazored OSS library for browser-local storage
builder.Services.AddBlazoredLocalStorage();

// Add device-specific services used by the HoneyDo.Shared project
builder.Services.AddScoped<ILocalStorage, LocalStorage>();
builder.Services.AddSingleton<IPhotoManager, PhotoManager>();

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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(HoneyDo.Shared._Imports).Assembly,
        typeof(HoneyDo.Web.Client._Imports).Assembly);

app.Run();
