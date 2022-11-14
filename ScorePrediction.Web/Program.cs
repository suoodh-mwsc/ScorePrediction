using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScorePrediction.Web.Models;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("PredictionConnectionString");
// Add Seed Initializer | By MS
builder.Services.AddTransient<DataSeeder>();
// DbContext | By MS
//builder.Services.AddDbContext<ScorePredictionDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("PredictionConnectionString")));
builder.Services.AddDbContext<ScorePredictionDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


if (app.Environment.IsDevelopment())
{
    SeedData(app);
}


//Seed Data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var service = scope.ServiceProvider.GetService<DataSeeder>();
            service.Seed();
        }
        catch (AmbiguousMatchException)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError("An error occurred while seeding the database");
        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.Run();
