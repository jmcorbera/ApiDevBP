using ApiDevBP.Business.Contract;
using ApiDevBP.Business.Implementation;
using ApiDevBP.DataAccess.Contract;
using ApiDevBP.DataAccess.Implementation;
using ApiDevBP.DataAccess.Settings;
using ApiDevBP.Service.Contract;
using ApiDevBP.Service.Implementation;
using ApiDevBP.Service.Mapper;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
    });
    var xmlFilename = $"./Documentation.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();

builder.Services.AddSingleton(provider =>
    new MapperConfiguration(Config =>
    {
        Config.AddProfile<UserProfile>();
    }).CreateMapper()
);

builder.Services.Configure<DBOptions>(builder.Configuration.GetSection("Database"));

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
