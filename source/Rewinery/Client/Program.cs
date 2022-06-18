using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Rewinery.Client;
using Rewinery.Client.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Rewinery.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
    //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped<HttpCategoriesRepository>();
builder.Services.AddScoped<HttpSubcategoryRepository>();
builder.Services.AddScoped<HttpIngredientRepository>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Rewinery.ServerAPI"));

builder.Services.AddApiAuthorization();

//MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();