using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VideoGamesCQRS.Common;
using VideoGamesCQRS.Data;
using FluentValidation;
using System;
using VideoGamesCQRS.Features.Players.CreatePlayer;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<VideoGameAppDbContext>(options => options.UseInMemoryDatabase("VideoGameDB"));
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
//Validation:2
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IValidator<CreatePlayerCommand>, CreatePlayerCommandValidator>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
    //Validation:2
    configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
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
