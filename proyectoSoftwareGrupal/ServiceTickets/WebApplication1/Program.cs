using Aplication.Interfaces;
using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicket;
using Aplication.Interfaces.ITicketCategory;
using Aplication.Interfaces.ITicketComment;
using Aplication.UseCase;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketQuery, TicketQuery>();
builder.Services.AddScoped<ITicketQuery, TicketQuery>();
builder.Services.AddScoped<ITicketCommand, TicketCommand>();

builder.Services.AddScoped<ITicketLogCommand, TicketLogCommand>();

builder.Services.AddScoped<IAreaCommand, AreaCommand>();
builder.Services.AddScoped<IAreaQuery, AreaQuery>();
builder.Services.AddScoped<IAreaService, AreaService>();

builder.Services.AddScoped<ITicketCategoryCommand, TicketCategoryCommand>();
builder.Services.AddScoped<ITicketCategoryQuery, TicketCategoryQuery>();
builder.Services.AddScoped<ITicketCategoryService, TicketCategoryService>();

builder.Services.AddScoped<ITicketCommentCommand, TicketCommentCommand>();
builder.Services.AddScoped<ITicketCommentQuery, TicketCommentQuery>();
builder.Services.AddScoped<ITicketCommentService, TicketCommentService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        List<SecurityKey> keys = new List<SecurityKey>() { };
        SecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Inter202211111111"));
        keys.Add(key);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKeys = keys,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
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

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
