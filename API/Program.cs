using Microsoft.AspNetCore.Mvc;
using TravelApp.API.Filters;
using TravelApp.Application;
using TravelApp.Infrastructure;
using TravelApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//My Services
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureShared(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers(options =>
    options.Filters.Add(new ApiExceptionFilter()));

builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true
    );

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
