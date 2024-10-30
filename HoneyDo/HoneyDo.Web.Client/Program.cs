using HoneyDo.Shared.Interfaces;
using HoneyDo.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Use Blazored OSS library for browser-local storage
builder.Services.AddBlazoredLocalStorageAsSingleton();

// Add device-specific services used by the HoneyDo.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddSingleton<ILocalStorage, LocalStorage>();
builder.Services.AddSingleton<IPhotoManager, PhotoManager>();

await builder.Build().RunAsync();
