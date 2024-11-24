using ElevenIsland.API.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContextFactory<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseForwardedHeaders();
app.UseCors(options => options.AllowAnyOrigin());
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://*:7234");