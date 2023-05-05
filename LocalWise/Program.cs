using LocalWise.Data;
using LocalWise.Helpers;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.Repository;
using LocalWise.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGerenteLocalRepository, GerenteLocalRepository>();
builder.Services.AddScoped<IGuiaRepository, GuiaRepository>();
builder.Services.AddScoped<ITuristaRepository, TuristaRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

builder.Services.AddDbContext<LWDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
