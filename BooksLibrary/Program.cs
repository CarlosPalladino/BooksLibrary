using BooksLibrary.Conexion;
using BooksLibrary.Interfaces;
using BooksLibrary.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConexionDB>(
builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton<ClientRepository>();
builder.Services.AddSingleton<LibropRepository>();
builder.Services.AddScoped<ClienteInterface, ClientRepository>();
builder.Services.AddScoped<LibrosInterface, LibropRepository>();
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
