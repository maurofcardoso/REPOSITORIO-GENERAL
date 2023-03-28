using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICarritoProducto;
using Application.Interfaces.ICliente;
using Application.Interfaces.IOrden;
using Application.Interfaces.IProducto;
using Application.Interfaces.ServicesPresentation;
using Application.UseCase.CarritoProductos;
using Application.UseCase.Carritos;
using Application.UseCase.ChangeModels;
using Application.UseCase.Clientes;
using Application.UseCase.Ordenes;
using Application.UseCase.Productos;
using Infraestructure.Command.CarritoProductos;
using Infraestructure.Command.Carritos;
using Infraestructure.Command.Clientes;
using Infraestructure.Command.Ordenes;
using Infraestructure.Command.Productos;
using Infraestructure.Persistence;
using Infraestructure.Query.CarritoProductos;
using Infraestructure.Query.Carritos;
using Infraestructure.Query.Clientes;
using Infraestructure.Query.Ordenes;
using Infraestructure.Query.Productos;
using Microsoft.EntityFrameworkCore;
using Presentation.MenuServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//creo inyeccion conexion base datos
var connectionString = builder.Configuration["connectionString"];
builder.Services.AddDbContext<ProyectoSoftwareContext>(options => options.UseSqlServer(connectionString));

//inyeccion de dependencias
builder.Services.AddScoped<ICarritoCommand, CarritoCommand>();
builder.Services.AddScoped<ICarritoQuery, CarritoQuery>();
builder.Services.AddScoped<ICarritoServiceCommand, CarritoServiceCommand>();
builder.Services.AddScoped<ICarritoServiceQuery, CarritoServiceQuery>();

builder.Services.AddScoped<ICarritoProductoCommand, CarritoProductoCommand>();
builder.Services.AddScoped<ICarritoProductoQuery, CarritoProductoQuery>();
builder.Services.AddScoped<ICarritoProductoServiceCommand, CarritoProductoServiceCommand>();
builder.Services.AddScoped<ICarritoProductoServiceQuery, CarritoProductoServiceQuery>();

builder.Services.AddScoped<IClienteCommand, ClienteCommand>();
builder.Services.AddScoped<IClienteQuery, ClienteQuery>();
builder.Services.AddScoped<IClienteServiceCommand, ClienteServiceCommand>();
builder.Services.AddScoped<IClienteServiceQuery, ClienteServiceQuery>();

builder.Services.AddScoped<IOrdenCommand, OrdenCommand>();
builder.Services.AddScoped<IOrdenQuery, OrdenQuery>();
builder.Services.AddScoped<IOrdenServiceCommand, OrdenServiceCommand>();
builder.Services.AddScoped<IOrdenServiceQuery, OrdenServiceQuery>();

builder.Services.AddScoped<IProductoCommand, ProductoCommand>();
builder.Services.AddScoped<IProductoQuery, ProductoQuery>();
builder.Services.AddScoped<IProductoServiceCommand, ProductoServiceCommand>();
builder.Services.AddScoped<IProductoServiceQuery, ProductoServiceQuery>();

builder.Services.AddScoped<IChangeModels, ChangeModels>();
builder.Services.AddScoped<IServicesPresentation, ServicesPresentation>();

//configuracion cors
builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
