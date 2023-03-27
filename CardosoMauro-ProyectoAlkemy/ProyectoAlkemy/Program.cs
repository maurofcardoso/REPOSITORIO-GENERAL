using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.SendEmails;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Mappers.MapperDisney;
using Application.Models.Common;
using Application.Models.Request;
using Application.Tools;
using Application.UseCase.Characters;
using Application.UseCase.CharactersMoviesOrSeries;
using Application.UseCase.Genders;
using Application.UseCase.MoviesOrSeries;
using Application.UseCase.Users;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Extensions.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//jwt configuration
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

var appSettings = appSettingsSection.Get<AppSettings>();
var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);

builder.Services.AddAuthentication(configureOptions: options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;//tostring()
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(llave),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true,
        };
    });

//connection bd
var connectionString = builder.Configuration["connectionString"];
builder.Services.AddDbContext<ProyectoAlkemyContext>(options => options.UseSqlServer(connectionString));

//configuration sendGrip
builder.Services.AddSendGrid(options =>
{
    options.ApiKey = builder.Configuration.GetSection("SendGridSettings").GetValue<string>("APIkey");
});


builder.Services.AddScoped(typeof(IQueryWithCharacter<CharacterRequest, Character>), typeof(QueryCharacter));
builder.Services.AddScoped(typeof(IServiceQueryWithCharacter<CharacterRequest, Character>), typeof(CharacterService));
builder.Services.AddScoped(typeof(ICommand<Character>), typeof(CommandCharacter));
builder.Services.AddScoped(typeof(IQuery<Character>), typeof(QueryCharacter));
builder.Services.AddScoped(typeof(IServiceCommand<CharacterRequest, Character>), typeof(CharacterService));
builder.Services.AddScoped(typeof(IServiceQuery<Character>), typeof(CharacterService));

builder.Services.AddScoped(typeof(ICommand<Gender>), typeof(CommandGender));
builder.Services.AddScoped(typeof(IQuery<Gender>), typeof(QueryGender));
builder.Services.AddScoped(typeof(IServiceCommand<GenderRequest, Gender>), typeof(GenderService));
builder.Services.AddScoped(typeof(IServiceQuery<Gender>), typeof(GenderService));

builder.Services.AddScoped(typeof(ICommand<CharacterMovieOrSerie>), typeof(CommandCharacterMovieOrSerie));
builder.Services.AddScoped(typeof(IQuery<CharacterMovieOrSerie>), typeof(QueryCharacterMovieOrSerie));
builder.Services.AddScoped(typeof(IServiceCommand<CharacterMovieOrSerieRequest, CharacterMovieOrSerie>), typeof(CharacterMovieOrSerieService));
builder.Services.AddScoped(typeof(IServiceQuery<CharacterMovieOrSerie>), typeof(CharacterMovieOrSerieService));

builder.Services.AddScoped(typeof(ICommand<MovieOrSerie>), typeof(CommandMovieOrSerie));
builder.Services.AddScoped(typeof(IQuery<MovieOrSerie>), typeof(QueryMovieOrSerie));
builder.Services.AddScoped(typeof(IServiceCommand<MovieOrSerieRequest, MovieOrSerie>), typeof(MovieOrSerieService));
builder.Services.AddScoped(typeof(IServiceQuery<MovieOrSerie>), typeof(MovieOrSerieService));
builder.Services.AddScoped(typeof(IQueryWithMovieOrSerie<MovieOrSerie>), typeof(QueryMovieOrSerie));
builder.Services.AddScoped(typeof(IServiceQueryWithMovieOrSerie<MovieOrSerie>), typeof(MovieOrSerieService));

builder.Services.AddScoped(typeof(ICommand<User>), typeof(CommandUser));
builder.Services.AddScoped(typeof(IQuery<User>), typeof(QueryUser));
builder.Services.AddScoped(typeof(IQueryWithUser<User>), typeof(QueryUser));
builder.Services.AddScoped(typeof(IServiceCommand<UserRequest, User>), typeof(UserService));
builder.Services.AddScoped(typeof(IServiceQuery<User>), typeof(UserService));
builder.Services.AddScoped(typeof(IServiceQueryWithUser<User>), typeof(UserService));

builder.Services.AddScoped<IMapperDisney, MapperDisney>();
builder.Services.AddScoped<ISendEmail, SendEmail>();

//cors configuration
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
