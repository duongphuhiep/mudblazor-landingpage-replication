using DaisyMudDomain;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddLogging();
builder.Services.AddLucideIcons();
builder.Services.AddMudDomainServices();
await builder.Build().RunAsync();