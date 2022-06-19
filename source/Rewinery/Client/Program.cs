using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Rewinery.Client;
using Rewinery.Client.Infrastructure.HttpCellar;
using Rewinery.Client.Infrastructure.HttpOrder;
using Rewinery.Client.Infrastructure.HttpTopic;
using Rewinery.Client.Infrastructure.HttpWines;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Rewinery.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

#region http-repository
builder.Services.AddScoped<HttpWineRepository>();
builder.Services.AddScoped<HttpGrapeRepository>();
builder.Services.AddScoped<HttpCategoryRepository>();
builder.Services.AddScoped<HttpSubcategoryRepository>();
builder.Services.AddScoped<HttpIngredientRepository>();
builder.Services.AddScoped<HttpCommentRepository>();
builder.Services.AddScoped<HttpCommentResponseRepository>();

builder.Services.AddScoped<HttpOrderRepository>();
builder.Services.AddScoped<HttpOrderStatusRepository>();

builder.Services.AddScoped<HttpCellarRepository>();
builder.Services.AddScoped<HttpCellarRentalRepository>();

builder.Services.AddScoped<HttpTopicRepository>();
builder.Services.AddScoped<HttpAnswerRepository>();
builder.Services.AddScoped<HttpAnswerResponseRepository>();
#endregion

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Rewinery.ServerAPI"));

builder.Services.AddApiAuthorization();

//MudBlazor
builder.Services.AddMudServices();

await builder.Build().RunAsync();