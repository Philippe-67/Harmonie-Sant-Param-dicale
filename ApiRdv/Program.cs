//using ApiRdv.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//builder.Services.AddDbContext<RdvDbContext>(options =>
//    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using ApiRdv.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<RdvService>();
builder.Services.AddScoped<RdvRepository>();

builder.Services.AddDbContext<RdvDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

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

//app.UseAuthorization();

app.MapControllers();

app.Run();

