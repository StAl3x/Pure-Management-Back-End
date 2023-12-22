using Domain.DTOs;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("initializing");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


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
    configuration.CreateMap<PostProductInWarehouseDTO, ProductInWarehouse>();
    configuration.CreateMap<PutProductInWarehouseDTO, ProductInWarehouse>();
    configuration.CreateMap<PostUserInWarehouseDTO, UserInWarehouse>();
    configuration.CreateMap<PutUserInWarehouseDTO, UserInWarehouse>();
    configuration.CreateMap<PostProductDTOWithQuantity, Product>();
    configuration.CreateMap<PutProductDTOWithQuantity, Product>();

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
