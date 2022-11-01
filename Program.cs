using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using codeTopGBlazorWasm;
using codeTopGBlazorWasm.ApiServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IGetWeatherApi, GetWeatherApi>();
builder.Services.AddScoped<IGetCoords, GetCoords>();
builder.Services.AddScoped<IHashNodeGqlApi, HashNodeGqlApi>();

await builder.Build().RunAsync();
