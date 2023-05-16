using LocalWise.Controllers;
using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IAccountRepository, AccountRepository >();

builder.Services.AddDbContext<LWDbContext>(options =>
{
    options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConection"));
});
builder.Services.AddIdentity<Pessoa, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<LWDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
