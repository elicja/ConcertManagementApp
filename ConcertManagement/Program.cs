using DataAccess.Data;
using DataAccess.Implementation;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); 

builder.Services.AddDbContext<DataDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IConcertProvider, ConcertProvider>();
builder.Services.AddScoped<IPerformenceProvider, PerformenceProvider>();
builder.Services.AddScoped<IMusicGenreProvider, MusicGenreProvider>();
builder.Services.AddScoped<IArtistProvider, ArtistProvider>();
builder.Services.AddScoped<ICityProvider, CityProvider>();

var app = builder.Build();

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
    pattern: "{controller=ConcertInfo}/{action=Index}/{id?}");

app.Run();
