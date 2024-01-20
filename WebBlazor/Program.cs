using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebBlazor;
using WebBlazor.Services;
using WebBlazor.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiGateway = builder.Configuration["apiGateway"];

builder.Services.AddBlazoredToast();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiGateway) });
builder.Services.AddScoped<IPostsService, PostsServices>();

await builder.Build().RunAsync();
