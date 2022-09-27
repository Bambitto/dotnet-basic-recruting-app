using MatchDataManager.Api.Data;
using MatchDataManager.Api.Repositories;
using MatchDataManager.Api.Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using MatchDataManager.Api.Validation;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IValidator<Location>, LocationValidator>();
builder.Services.AddScoped<IValidator<Team>, TeamValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();