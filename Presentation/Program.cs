using Application.Interfaces.AccountQuests;
using Application.Interfaces.Accounts;
using Application.Interfaces.Cars;
using Application.Interfaces.Quests;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<IQuestRepository, QuestRepository>();

builder.Services.AddScoped<IAccountQuestService, AccountQuestService>();
builder.Services.AddScoped<IAccountQuestRepository, AccountQuestRepository>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.MapControllers();

app.Run();