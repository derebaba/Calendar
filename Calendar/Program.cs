using Calendar.Infrastructure.Persistance;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Calendar"));

var app = builder.Build();

var culture = CultureInfo.CreateSpecificCulture("en-US");
var dateformat = new DateTimeFormatInfo
{
    ShortDatePattern = "MM/dd/yyyy",
    LongTimePattern = "hh:mm tt"
};
culture.DateTimeFormat = dateformat;

var supportedCultures = new[]
{
    culture
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
CultureInfo.DefaultThreadCurrentUICulture = culture;
CultureInfo.DefaultThreadCurrentCulture = culture;

var scopeFactory = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IServiceScopeFactory>();
using (var context = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>())
{
    DatabaseInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
