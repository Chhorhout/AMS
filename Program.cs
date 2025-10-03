using AMS.Api.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using AMS.Api.Mapping;
using AMS.Api.Data.Configs;
using AMS.Api.Models;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbcontext>(action => {
    action.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials();
        });
});
var app = builder.Build();
app.UseCors("AllowLocalhost3000");
app.MapControllers();
app.Run();