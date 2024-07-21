using Aplication.Helper;
using Aplication.Interfaces;
using Aplication.Interfaces.Area;
using Aplication.Interfaces.Helpers;
using Aplication.UseCase;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];
//Add custom services
builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserCommand, UserCommand>();
builder.Services.AddScoped<IUserQuery, UserQuerys>();

builder.Services.AddScoped<IRolServices, RolServices>();
builder.Services.AddScoped<IRolCommand, RolCommand>();
builder.Services.AddScoped<IRolQuery, RolQuerys>();

builder.Services.AddScoped<IPermissionServices, PermissionServices>();
builder.Services.AddScoped<IPermissionCommand, PermissionCommand>();
builder.Services.AddScoped<IPermissionQuery, PermissionQuerys>();

builder.Services.AddScoped<IAreaQuery, AreaQuerys>();

builder.Services.AddScoped<IAuthorizer, Authorizer>();


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
