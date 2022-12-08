using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using zsat.Models;
using Azure.Identity;
using zsat.Interfaces;
using zsat.Managers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ZsatDbContext>(options => options.UseSqlServer(config.GetConnectionString("ZsatConnection")));

// DONT TOUCH IT WILL BLOW UP Interface is needed 100%
builder.Services.AddScoped<IAttendance, AttendanceManager>();
builder.Services.AddScoped<IAuthUser, AuthUserManager>();
builder.Services.AddScoped<IStudent, StudentManager>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
