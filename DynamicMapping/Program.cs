using DynamicMapping.Core;
using DynamicMapping.Services.Fetaures.MappingAltos;
using DynamicMapping.Services.Fetaures.MappingBnb;
using DynamicMapping.Services.Fetaures.MappingBooking;
using FluentValidation;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register services and handlers
builder.Services.AddTransient<IParserEngine, ParserEngine>()
    .AddTransient<IMappingEngine, MappingEngineAltosHandler>()
    .AddTransient<IMappingEngine, MappingEngineBnbHandler>()
    .AddTransient<IMappingEngine, MappingEngineBookingHandler>()
    .AddTransient<IMappingEngineHandler, MappingEngineHandler>();

// register validators
builder.Services.AddScoped(typeof(IValidator<MappingModelBase>), typeof(MappingModelBaseValidator<>));
builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();
builder.Services.AddScoped<IValidator<MappingModelAltos>, MappingModelAltosValidator>();

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
