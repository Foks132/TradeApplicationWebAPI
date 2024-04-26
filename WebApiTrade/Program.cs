using Microsoft.EntityFrameworkCore;
using WebApiTrade.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Строка подключения к базе данных из конфигурации
string stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//Добавляем контекст базы данных сиспользованием SQL Server
builder.Services.AddDbContext<Trade_dbContext>(o => o.UseSqlServer(stringConnection));
//Игнорирование циклов
builder.Services.AddControllers().AddJsonOptions(o =>
o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

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
