using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using PhishyBank.Data;

var builder = WebApplication.CreateBuilder(args);
var _connectionString = builder.Configuration.GetConnectionString("PhishyBankDatabase");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<BankContext>(options =>
  options
    .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
);
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BankContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
