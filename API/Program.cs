using Application.DTOs;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("initializing");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


var mapper = new MapperConfiguration(configuration =>
{
    configuration.CreateMap<PostProductDTO, Product>();
    configuration.CreateMap<PutProductDTO, Product>();
    configuration.CreateMap<PostWarehouseDTO, Warehouse>();
    configuration.CreateMap<PutWarehouseDTO, Warehouse>();
    configuration.CreateMap<PostCompanyDTO, Company>();
    configuration.CreateMap<PutCompanyDTO, Company>();
    configuration.CreateMap<PostUserDTO, User>();
    configuration.CreateMap<PutUserDTO, User>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PureManagementConnection")));


Application.DependencyResolver
    .DependencyResolverService
    .RegisterApplicationLayer(builder.Services);

Infrastructure.DependencyResolver
    .DependencyResolverService
    .RegisterInfrastructure(builder.Services);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
