using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyCompany.Store.SPA;
using MyCompany.Store.SPA.Services;
using MyCompany.Store.SPA.Services.Contracts;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5028") });
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<DialogService>();

await builder.Build().RunAsync();
