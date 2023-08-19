using LojaRepositorios.DependencyInjections;
using LojaServicos.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Adicionar as classes concretas com suas interfaces na injeção de dependência (interface, dependencia)
builder.Services
    .AddSwaggerGen()
    .AddServiceDependencyInjection()
    .AddRepositoryDependencyInjection(builder.Configuration);


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
