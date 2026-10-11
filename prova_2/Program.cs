using prova_2.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IJogadorRepository, JogadorRepository>();

builder.Services.AddControllers();
// https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
