using DynamicMapping.Core;
using DynamicMapping.Services.Fetaures.MappingAltos;
using DynamicMapping.Services.Fetaures.MappingBnb;
using DynamicMapping.Services.Fetaures.MappingBooking;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

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
builder.Services.AddScoped(typeof(IValidator<>), typeof(MappingModelBaseValidator<>));
builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();
builder.Services.AddScoped<IValidator<MappingModelAltos>, MappingModelAltosValidator>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
