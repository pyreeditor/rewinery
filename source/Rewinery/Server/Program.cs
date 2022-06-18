using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Rewinery.Server.Core;
using Rewinery.Server.Core.Models;
using Microsoft.AspNetCore.Identity;
using Rewinery.Server.Infrastructure;
using Rewinery.Server.Infrastructure.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


builder.Services.AddScoped<SubcategoryRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<GrapeRepository>();
builder.Services.AddScoped<IngredientRepository>();
builder.Services.AddScoped<WineRepository>();
builder.Services.AddScoped<AnswerRepository>();
builder.Services.AddScoped<AnswerResponseRepository>();
builder.Services.AddScoped<TopicRepository>();
builder.Services.AddScoped<CommentResponseRepository>();
builder.Services.AddScoped<WineCommentRepository>();
builder.Services.AddScoped<OrderStatusRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
