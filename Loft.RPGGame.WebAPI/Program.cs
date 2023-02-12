using Loft.RPGGame.Application.Implementations;
using Loft.RPGGame.Domain.Interfaces;
using Loft.RPGGame.Infrastructure.Services;
using Loft.RPGGame.Infrastructure.Singleton;
using Loft.RPGGame.WebAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IOccupationService, OccupationService>();
builder.Services.AddTransient<IOccupationFactory, OccupationFactory>();
builder.Services.AddTransient<IBattleService, BattleService>();
builder.Services.AddAutoMapper(typeof(CharacterProfile).Assembly);

CharactersSingleton.GetInstance();

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
